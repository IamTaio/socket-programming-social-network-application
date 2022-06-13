namespace client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logs = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.textBox1_username = new System.Windows.Forms.TextBox();
            this.connect_button = new System.Windows.Forms.Button();
            this.disconnect_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1_post = new System.Windows.Forms.TextBox();
            this.button1_send = new System.Windows.Forms.Button();
            this.button2_allposts = new System.Windows.Forms.Button();
            this.textBox1_postTBD = new System.Windows.Forms.TextBox();
            this.textBox2_friend = new System.Windows.Forms.TextBox();
            this.friendlogs = new System.Windows.Forms.RichTextBox();
            this.Myposts_button = new System.Windows.Forms.Button();
            this.friends_post_button = new System.Windows.Forms.Button();
            this.Add_friend_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.remove_friend_button = new System.Windows.Forms.Button();
            this.textBoxRemove_Friend = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logs
            // 
            this.logs.Enabled = false;
            this.logs.Location = new System.Drawing.Point(501, 21);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(323, 491);
            this.logs.TabIndex = 0;
            this.logs.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(95, 16);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(178, 22);
            this.textBox_ip.TabIndex = 4;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(95, 50);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(178, 22);
            this.textBox_port.TabIndex = 5;
            // 
            // textBox1_username
            // 
            this.textBox1_username.Location = new System.Drawing.Point(95, 89);
            this.textBox1_username.Name = "textBox1_username";
            this.textBox1_username.Size = new System.Drawing.Size(178, 22);
            this.textBox1_username.TabIndex = 6;
            // 
            // connect_button
            // 
            this.connect_button.AutoSize = true;
            this.connect_button.Location = new System.Drawing.Point(287, 15);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(129, 27);
            this.connect_button.TabIndex = 7;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // disconnect_button
            // 
            this.disconnect_button.AutoSize = true;
            this.disconnect_button.Enabled = false;
            this.disconnect_button.Location = new System.Drawing.Point(287, 53);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(129, 27);
            this.disconnect_button.TabIndex = 8;
            this.disconnect_button.Text = "Disconnect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            this.disconnect_button.Click += new System.EventHandler(this.disconnect_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Post:";
            // 
            // textBox1_post
            // 
            this.textBox1_post.Enabled = false;
            this.textBox1_post.Location = new System.Drawing.Point(95, 490);
            this.textBox1_post.Name = "textBox1_post";
            this.textBox1_post.Size = new System.Drawing.Size(244, 22);
            this.textBox1_post.TabIndex = 10;
            // 
            // button1_send
            // 
            this.button1_send.AutoSize = true;
            this.button1_send.Enabled = false;
            this.button1_send.Location = new System.Drawing.Point(354, 485);
            this.button1_send.Name = "button1_send";
            this.button1_send.Size = new System.Drawing.Size(114, 27);
            this.button1_send.TabIndex = 11;
            this.button1_send.Text = "Send";
            this.button1_send.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1_send.UseVisualStyleBackColor = true;
            this.button1_send.Click += new System.EventHandler(this.button1_send_Click);
            // 
            // button2_allposts
            // 
            this.button2_allposts.AutoSize = true;
            this.button2_allposts.Enabled = false;
            this.button2_allposts.Location = new System.Drawing.Point(501, 529);
            this.button2_allposts.Name = "button2_allposts";
            this.button2_allposts.Size = new System.Drawing.Size(75, 27);
            this.button2_allposts.TabIndex = 12;
            this.button2_allposts.Text = "All Posts";
            this.button2_allposts.UseVisualStyleBackColor = true;
            this.button2_allposts.Click += new System.EventHandler(this.button2_allposts_Click);
            // 
            // textBox1_postTBD
            // 
            this.textBox1_postTBD.Enabled = false;
            this.textBox1_postTBD.Location = new System.Drawing.Point(95, 529);
            this.textBox1_postTBD.Name = "textBox1_postTBD";
            this.textBox1_postTBD.Size = new System.Drawing.Size(244, 22);
            this.textBox1_postTBD.TabIndex = 14;
            // 
            // textBox2_friend
            // 
            this.textBox2_friend.Enabled = false;
            this.textBox2_friend.Location = new System.Drawing.Point(95, 444);
            this.textBox2_friend.Name = "textBox2_friend";
            this.textBox2_friend.Size = new System.Drawing.Size(244, 22);
            this.textBox2_friend.TabIndex = 15;
            // 
            // friendlogs
            // 
            this.friendlogs.Enabled = false;
            this.friendlogs.Location = new System.Drawing.Point(95, 192);
            this.friendlogs.Name = "friendlogs";
            this.friendlogs.Size = new System.Drawing.Size(244, 151);
            this.friendlogs.TabIndex = 16;
            this.friendlogs.Text = "";
            // 
            // Myposts_button
            // 
            this.Myposts_button.AutoSize = true;
            this.Myposts_button.Enabled = false;
            this.Myposts_button.Location = new System.Drawing.Point(610, 568);
            this.Myposts_button.Name = "Myposts_button";
            this.Myposts_button.Size = new System.Drawing.Size(75, 27);
            this.Myposts_button.TabIndex = 17;
            this.Myposts_button.Text = "My Posts";
            this.Myposts_button.UseVisualStyleBackColor = true;
            this.Myposts_button.Click += new System.EventHandler(this.Myposts_button_Click);
            // 
            // friends_post_button
            // 
            this.friends_post_button.AutoSize = true;
            this.friends_post_button.Enabled = false;
            this.friends_post_button.Location = new System.Drawing.Point(717, 529);
            this.friends_post_button.Name = "friends_post_button";
            this.friends_post_button.Size = new System.Drawing.Size(107, 27);
            this.friends_post_button.TabIndex = 18;
            this.friends_post_button.Text = "Friend\'s Posts";
            this.friends_post_button.UseVisualStyleBackColor = true;
            this.friends_post_button.Click += new System.EventHandler(this.friends_post_button_Click);
            // 
            // Add_friend_button
            // 
            this.Add_friend_button.AutoSize = true;
            this.Add_friend_button.Enabled = false;
            this.Add_friend_button.Location = new System.Drawing.Point(354, 444);
            this.Add_friend_button.Name = "Add_friend_button";
            this.Add_friend_button.Size = new System.Drawing.Size(114, 27);
            this.Add_friend_button.TabIndex = 19;
            this.Add_friend_button.Text = "Add Friend";
            this.Add_friend_button.UseVisualStyleBackColor = true;
            this.Add_friend_button.Click += new System.EventHandler(this.Add_friend_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Enabled = false;
            this.Delete_button.Location = new System.Drawing.Point(354, 528);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(114, 23);
            this.Delete_button.TabIndex = 20;
            this.Delete_button.Text = "Delete";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // remove_friend_button
            // 
            this.remove_friend_button.AutoSize = true;
            this.remove_friend_button.Enabled = false;
            this.remove_friend_button.Location = new System.Drawing.Point(354, 399);
            this.remove_friend_button.Name = "remove_friend_button";
            this.remove_friend_button.Size = new System.Drawing.Size(114, 27);
            this.remove_friend_button.TabIndex = 21;
            this.remove_friend_button.Text = "Remove Friend";
            this.remove_friend_button.UseVisualStyleBackColor = true;
            this.remove_friend_button.Click += new System.EventHandler(this.remove_friend_button_Click);
            // 
            // textBoxRemove_Friend
            // 
            this.textBoxRemove_Friend.Enabled = false;
            this.textBoxRemove_Friend.Location = new System.Drawing.Point(95, 400);
            this.textBoxRemove_Friend.Name = "textBoxRemove_Friend";
            this.textBoxRemove_Friend.Size = new System.Drawing.Size(244, 22);
            this.textBoxRemove_Friend.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Username:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 528);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "PostID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "Friend list:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 626);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxRemove_Friend);
            this.Controls.Add(this.remove_friend_button);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.Add_friend_button);
            this.Controls.Add(this.friends_post_button);
            this.Controls.Add(this.Myposts_button);
            this.Controls.Add(this.friendlogs);
            this.Controls.Add(this.textBox2_friend);
            this.Controls.Add(this.textBox1_postTBD);
            this.Controls.Add(this.button2_allposts);
            this.Controls.Add(this.button1_send);
            this.Controls.Add(this.textBox1_post);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.textBox1_username);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.TextBox textBox1_username;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Button disconnect_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1_post;
        private System.Windows.Forms.Button button1_send;
        private System.Windows.Forms.Button button2_allposts;
        private System.Windows.Forms.TextBox textBox1_postTBD;
        private System.Windows.Forms.TextBox textBox2_friend;
        private System.Windows.Forms.RichTextBox friendlogs;
        private System.Windows.Forms.Button Myposts_button;
        private System.Windows.Forms.Button friends_post_button;
        private System.Windows.Forms.Button Add_friend_button;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.Button remove_friend_button;
        private System.Windows.Forms.TextBox textBoxRemove_Friend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

