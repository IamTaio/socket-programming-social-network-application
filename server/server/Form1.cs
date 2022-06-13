using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        public Mutex mutex = new Mutex();
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        int postID = 0;

        bool listening = false;
        bool terminating = false;
        string[] usernames;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void listen_button_Click(object sender, EventArgs e)
        {
            int serverPort;
            string[] posts = File.ReadAllLines(@"../../posts.txt");
            int postnumbers = posts.GetLength(0);
            if (postnumbers >= 1)
            {
                string lastpost = posts[postnumbers - 1];
                string[] postdetails = lastpost.Split('/');
                string postkey = postdetails[2];
                int.TryParse(postkey, out postID); 
            }

            if (Int32.TryParse(port_textBox.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                usernames = File.ReadAllLines(@"../../user-db.txt");
                listening = true;
                listen_button.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                logs.AppendText("Please check port number \n");
            }
        }

        private void Accept()
        {
            bool verified = false;
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);

                    Byte[] buffer = new Byte[64];
                    newClient.Receive(buffer);

                    string username = Encoding.Default.GetString(buffer);
                    username = username.Substring(0, username.IndexOf("\0"));
                    foreach (string i in usernames)
                    {
                        if (i == username)
                        {
                            verified = true;
                        }
                    }
                    if (verified)
                    {
                        clientSockets.Add(newClient);
                        Byte[] verify = Encoding.Default.GetBytes("success");
                        newClient.Send(verify);
                        logs.AppendText(username + " is connected\n");

                        string path = @"../../friends/" + username + ".txt";
                        if (File.Exists(path))
                        {
                            string[] Friends = File.ReadAllLines(path);
                            foreach (string line in Friends)
                            {

                                if (line != "")
                                {
                                    Thread.Sleep(250);
                                    Byte[] friend = Encoding.Default.GetBytes("!*!*!*" + line + "\n");
                                    newClient.Send(friend); 
                                }
                                
                            }
                        }
                        else
                        {
                            File.Create(path);
                        }

                        Thread receiveThread = new Thread(() => Receive(username, newClient)); // updated
                        receiveThread.Start();
                    }
                    else
                    {
                        Byte[] verify = Encoding.Default.GetBytes("failure");
                        newClient.Send(verify);
                        logs.AppendText(username + "is not a db user\n");
                        newClient.Close();

                    }
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }

                }
          
                
            }
        }

        private void Receive(string username, Socket newClient)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    newClient.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    if (incomingMessage == "sHOW pOSTS 4536625427")
                    {
                        showposts(username, newClient);
                    }
                    else if(incomingMessage == "sHow My pOsTs 20**34")
                    {
                        showownposts(username, newClient);
                    }
                    else if(incomingMessage == "sHoW fRIENds Pos***")
                    {
                        showfriendposts(username, newClient);
                    }
                    else if (incomingMessage.Length > 7 && incomingMessage.Substring(0, 7) == "adD ***")
                    {
                        addFriend(username, newClient, incomingMessage);
                    }
                    else if (incomingMessage.Length > 10 && incomingMessage.Substring(0, 10) == "reMoVE ***")
                    {
                        removeFriend(username, newClient, incomingMessage);
                    }
                    else if (incomingMessage.Length > 10 && incomingMessage.Substring(0, 10) == "deLETE ***")
                    {
                        deletepost(username, newClient, incomingMessage);
                    }
                    else
                    {
                        Addtoposts(incomingMessage, username);
                        logs.AppendText(username + "has sent a post\n");
                        logs.AppendText(incomingMessage + "\n");
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("A client has disconnected\n");
                    }
                    newClient.Close();
                    clientSockets.Remove(newClient);
                    connected = false;
                }
            }
        }

        private void deletepost(string username, Socket newClient, string incomingMessage)
        {
            string postkeyTBD = incomingMessage.Substring(10);
            bool postexists = false;
            string ToBeDeleted = "";
            string[] initposts = File.ReadAllLines(@"../../posts.txt");
            List<string> Postlist = new List<string>();
            foreach (string line in initposts)
            {
                string[] postdetails = line.Split('/');
                string user = postdetails[3];
                string postkey = postdetails[2];
                if (postkey == postkeyTBD)
                {
                    ToBeDeleted = line;
                    if (user != username)
                    {
                        Byte[] postbuffer = Encoding.Default.GetBytes("Post with ID " + postkeyTBD +" is not yours");
                        newClient.Send(postbuffer);
                        return;
                    }
                    else
                    {
                        postexists = true;
                    }   
                }
            }
            if (postexists)
            {
                foreach (string line in initposts)
                {
                    if (line != ToBeDeleted)
                    {
                        Postlist.Add(line);
                    }
                }
                string [] posts = Postlist.Select(i => i.ToString()).ToArray();
                File.WriteAllLines(@"../../posts.txt", posts);
                Byte[] postbuffer = Encoding.Default.GetBytes("Post with ID " + postkeyTBD + " has been deleted");
                newClient.Send(postbuffer);
                logs.AppendText(username + " has deleted a post\n");
            }
        }

        private void removeFriend(string username, Socket newClient, string incomingMessage)
        {
            string path = @"../../friends/" + username + ".txt";
            string ToBeDeleted = incomingMessage.Substring(10);
            if (File.Exists(path))
            {
                string[] Friends = File.ReadAllLines(path);
                List<string> Friendlist = new List<string>();
                if (Array.Exists(Friends, element => element == ToBeDeleted))
                {
                    
                    foreach(string line in Friends)
                    {
                        if (line != ToBeDeleted)
                        {
                            Friendlist.Add(line);
                        }
                    }
                    Friends = Friendlist.Select(i => i.ToString()).ToArray();
                    File.WriteAllLines(path, Friends);
                    foreach (string line in Friends)
                    {
                        Byte[] friend = Encoding.Default.GetBytes("!*!*!*" + line + "\n");
                        newClient.Send(friend);
                        Thread.Sleep(250); 
                    }
                }
                else
                {
                    Byte[] buffer = Encoding.Default.GetBytes(ToBeDeleted + " is not in your friend list!");
                    newClient.Send(buffer);
                }
            }
            string friendpath = @"../../friends/" + ToBeDeleted + ".txt";
            if (File.Exists(friendpath))
            {
                string[] users = File.ReadAllLines(path);
                List<string> Friendslist = new List<string>();
                if (Array.Exists(users, element => element == username))
                {

                    foreach (string line in users)
                    {
                        if (line != username)
                        {
                            Friendslist.Add(line);
                        }
                    }
                    users = Friendslist.Select(i => i.ToString()).ToArray();
                    File.WriteAllLines(friendpath, users);
                }
            }
            logs.AppendText(username + " has successfully removed " + ToBeDeleted + " from their friend list\n");
            Byte[] notifbuffer = Encoding.Default.GetBytes(ToBeDeleted + " has been removed from your friend list!");
            newClient.Send(notifbuffer);
        }

        private void addFriend(string username, Socket newClient, string incomingMessage)
        {
            bool friendexists = false;
            string friend = incomingMessage.Substring(7) ;
            string path = @"../../friends/" + username + ".txt";
            string friendpath = @"../../friends/" + friend + ".txt";
            foreach (string i in usernames)
            {
                if (i == friend)
                {
                    friendexists = true;
                }
            }

            if (!friendexists)
            {
                Byte[] buffer = Encoding.Default.GetBytes("There is no such user to add to your friend list");
                newClient.Send(buffer);
                return;
            }

          
            logs.AppendText(username + " has added " + friend + " to their friend list\n");
                
            using (StreamWriter file = new StreamWriter(path, append: true))
            {
                file.WriteLine(friend);
            }
                
          
            using (StreamWriter file = new StreamWriter(friendpath, append: true))
            {
                file.WriteLine(username);
            }
            Byte[] notifbuffer = Encoding.Default.GetBytes("You have successfully added " + friend + " to your friend list");
            newClient.Send(notifbuffer);
            Byte[] friendbuffer = Encoding.Default.GetBytes("!*!*!*" + friend + "\n");
            newClient.Send(friendbuffer);
        }

        private void showfriendposts(string username, Socket newClient)
        {
            string[] posts = File.ReadAllLines(@"../../posts.txt");
            string path = @"../../friends/" + username + ".txt";
            if (File.Exists(path))
            {
                string[] Friends = File.ReadAllLines(path);
                foreach (string line in posts)
                {
                    string[] postdetails = line.Split('/');
                    string user = postdetails[3];
                    string post = "*****" + line;
                    if (Array.Exists(Friends, element => element == user))
                    {
                        Thread.Sleep(500);
                        Byte[] postbuffer = Encoding.Default.GetBytes(post);
                        newClient.Send(postbuffer);
                    }
                }
            }
            logs.AppendText(username + " has displayed all their friends posts\n");   
        }

        private void showownposts(string username, Socket newClient)
        {
            string[] posts = File.ReadAllLines(@"../../posts.txt");
            foreach (string line in posts)
            {
                string[] postdetails = line.Split('/');
                string user = postdetails[3];
                string post = "*****" + line;
                if (user == username)
                {
                    Thread.Sleep(500);
                    Byte[] postbuffer = Encoding.Default.GetBytes(post);
                    newClient.Send(postbuffer);
                }
            }
            logs.AppendText(username + " has displayed their posts\n");
        }

        private void showposts(string username, Socket newClient)
        {
            string [] posts = File.ReadAllLines(@"../../posts.txt");
            foreach (string line in posts)
            {
                string[] postdetails = line.Split('/');
                string user = postdetails[3];
                string post = "*****" + line;
                if (user != username)
                {
                    Thread.Sleep(500);
                    Byte[] postbuffer = Encoding.Default.GetBytes(post);
                    newClient.Send(postbuffer);
                }
            }
        }

        private void Addtoposts(string incomingMessage, string username)
        {
            string[] posts = File.ReadAllLines(@"../../posts.txt");
            DateTime now = DateTime.Now;
            if (mutex.WaitOne())
            {
                string postkey = "";
                try
                {
                    postID++;
                    if (File.Exists(@"../../postIDs.txt"))
                    {
                        string[] postIDs = File.ReadAllLines(@"../../postIDs.txt");
                        int postnumbers = posts.GetLength(0);
                        if (postnumbers >= 1)
                        {
                            string lastpost = postIDs[postnumbers - 1];
                            postkey = lastpost;
                        }
                    }
                    else
                    {
                        postkey = postID.ToString();
                    }
                    
                    
                    string postline = now.ToString("s") + "/" + incomingMessage + "/" + postkey + "/" + username;
                    using (StreamWriter file = new StreamWriter(@"../../posts.txt", append: true))
                    {
                        file.WriteLine(postline);
                    }
                    using (StreamWriter file = new StreamWriter(@"../../postIDs.txt", append: true))
                    {
                        file.WriteLine(postkey);
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            
        }

    }
}

