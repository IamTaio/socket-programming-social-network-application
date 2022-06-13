using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;
        string username = "";

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_ip.Text;
            username = textBox1_username.Text;

            if (IP != "")
            {
                int portNum;
                if (Int32.TryParse(textBox_port.Text, out portNum))
                {
                    try
                    {
                        clientSocket.Connect(IP, portNum);
                        Byte[] buffer = Encoding.Default.GetBytes(username);
                        clientSocket.Send(buffer);
                        connect_button.Enabled = false;
                        try
                        {
                            Byte[] temp_buffer = new Byte[64];
                            clientSocket.Receive(temp_buffer);

                            string incomingMessage = Encoding.Default.GetString(temp_buffer);
                            incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                            if (incomingMessage == "success")
                            {
                                logs.AppendText("Hello " + username + "! You are connected to the server.\n");
                                connected = true;
                                textBox1_post.Enabled = true;
                                button2_allposts.Enabled = true;
                                button1_send.Enabled = true;
                                textBox1_username.Enabled = false;
                                textBox_ip.Enabled = false;
                                textBox_port.Enabled = false;
                                disconnect_button.Enabled = true;
                                Delete_button.Enabled = true;
                                remove_friend_button.Enabled = true;
                                Add_friend_button.Enabled = true;
                                logs.Enabled = true;
                                friendlogs.Clear();
                                friendlogs.Enabled = true;
                                textBox1_postTBD.Enabled = true;
                                textBox2_friend.Enabled = true;
                                textBoxRemove_Friend.Enabled = true;
                                Myposts_button.Enabled = true;
                                friends_post_button.Enabled = true;

                                Thread receiveThread = new Thread(Receive);
                                receiveThread.Start();
                            }
                            else if (incomingMessage == "failure")
                            {
                                logs.AppendText("Failed to connect, Please enter a valid username\n");
                                connect_button.Enabled = true;
                            }
                        }
                        catch
                        {
                            logs.AppendText("Failed to connect");
                        }

                    }
                    catch
                    {
                        logs.AppendText("Could not connect to the server!\n");
                    }
                }
                else
                {
                    logs.AppendText("Check the port\n");
                }
            }
            else
            {
                logs.AppendText("Empty IP Address");
            }
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[1024];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    if (incomingMessage.Length > 5 && incomingMessage.Substring(0, 5) == "*****")
                    {
                        string message = incomingMessage.Substring(5);
                        string[] post = message.Split('/');
                        logs.AppendText("Username: " + post[3] + "\n");
                        logs.AppendText("PostID: " + post[2] + "\n");
                        logs.AppendText("Post: " + post[1] + "\n");
                        logs.AppendText("Time: " + post[0] + "\n");
                        logs.AppendText("\n");
                        
                    }
                    else if (incomingMessage.Length > 5 && incomingMessage.Substring(0,6) == "!*!*!*")
                    {
                        string message = incomingMessage.Substring(6);
                        friendlogs.AppendText(message);
                    }
                    else
                    {
                        logs.AppendText(incomingMessage + "\n");
                    }


                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("The server has disconnected\n");
                        connect_button.Enabled = true;

                        disconnect_button.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void disconnect_button_Click(object sender, EventArgs e)
        {
            connected = false;
            disconnect_button.Enabled = false;
            textBox1_post.Enabled = false;
            button2_allposts.Enabled = false;
            button1_send.Enabled = false;
            Delete_button.Enabled = false;
            remove_friend_button.Enabled = false;
            Add_friend_button.Enabled = false;
            logs.Enabled = false;
            friendlogs.Clear();
            friendlogs.Enabled = false;
            textBox1_postTBD.Enabled = false;
            textBox2_friend.Enabled = false;
            textBoxRemove_Friend.Enabled = false;
            Myposts_button.Enabled = false;
            friends_post_button.Enabled = false; 
            textBox1_username.Enabled = true;
            textBox_ip.Enabled = true;
            textBox_port.Enabled = true;
            connect_button.Enabled = true;
            clientSocket.Close();
        }

        private void button1_send_Click(object sender, EventArgs e)
        {
            string message = textBox1_post.Text;

            if (message != "")
            {
                try
                {
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                    logs.AppendText("You have successfully sent a post\n");
                    logs.AppendText(username + ": " + message + "\n");
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("The server has disconnected\n");
                        connect_button.Enabled = true;

                        disconnect_button.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false;
                }
            }
        }

        private void button2_allposts_Click(object sender, EventArgs e)
        {
            try
            {
                Byte[] buffer = Encoding.Default.GetBytes("sHOW pOSTS 4536625427");
                clientSocket.Send(buffer);
                logs.AppendText("Showing all posts from clients:\n");
            }
            catch
            {

                if (!terminating)
                {
                    logs.AppendText("The server has disconnected\n");
                    connect_button.Enabled = true;

                    disconnect_button.Enabled = false;
                }

                clientSocket.Close();
                connected = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void remove_friend_button_Click(object sender, EventArgs e)
        {
            string message = textBoxRemove_Friend.Text;


            if (message != "")
            {
                try
                {
                    string prompt = "reMoVE ***" + message;
                    Byte[] buffer = Encoding.Default.GetBytes(prompt);
                    clientSocket.Send(buffer);
                    friendlogs.Clear();
                }
                catch
                {

                    if (!terminating)
                    {
                        logs.AppendText("The server has disconnected\n");
                        connect_button.Enabled = true;

                        disconnect_button.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false;
                } 
            }
        }

        private void Add_friend_button_Click(object sender, EventArgs e)
        {
            string message = textBox2_friend.Text;


            if (message != "")
            {
                try
                {
                    string prompt = "adD ***" + message;
                    Byte[] buffer = Encoding.Default.GetBytes(prompt);
                    clientSocket.Send(buffer);
                }
                catch
                {

                    if (!terminating)
                    {
                        logs.AppendText("The server has disconnected\n");
                        connect_button.Enabled = true;

                        disconnect_button.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false;
                }
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            string message = textBox1_postTBD.Text;
            int postkey;

            if (Int32.TryParse(textBox1_postTBD.Text, out postkey))
            {
                if (message != "")
                {
                    try
                    {
                        string prompt = "deLETE ***" + message;
                        Byte[] buffer = Encoding.Default.GetBytes(prompt);
                        clientSocket.Send(buffer);
                    }
                    catch
                    {

                        if (!terminating)
                        {
                            logs.AppendText("The server has disconnected\n");
                            connect_button.Enabled = true;

                            disconnect_button.Enabled = false;
                        }

                        clientSocket.Close();
                        connected = false;
                    }
                } 
            }
        }

        private void Myposts_button_Click(object sender, EventArgs e)
        {
            try
            {
                Byte[] buffer = Encoding.Default.GetBytes("sHow My pOsTs 20**34");
                clientSocket.Send(buffer);
                logs.AppendText("Showing all your posts:\n");
            }
            catch
            {

                if (!terminating)
                {
                    logs.AppendText("The server has disconnected\n");
                    connect_button.Enabled = true;

                    disconnect_button.Enabled = false;
                }

                clientSocket.Close();
                connected = false;
            }
        }

        private void friends_post_button_Click(object sender, EventArgs e)
        {
            try
            {
                Byte[] buffer = Encoding.Default.GetBytes("sHoW fRIENds Pos***");
                clientSocket.Send(buffer);
                logs.AppendText("Showing all posts from friends:\n");
            }
            catch
            {

                if (!terminating)
                {
                    logs.AppendText("The server has disconnected\n");
                    connect_button.Enabled = true;

                    disconnect_button.Enabled = false;
                }

                clientSocket.Close();
                connected = false;
            }
        }
    }
}
