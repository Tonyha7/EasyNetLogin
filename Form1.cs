using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace EasyNetLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            String username = UserUtils.GetUserName();
            String password = UserUtils.GetPassword();
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                textBox1.Text = username;
                textBox2.Text = password;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = UserUtils.GetUserName();
            String password = UserUtils.GetPassword();
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                String res = Login.login(IP.localIP, username, password);
                if (res != null)
                {
                    MessageBox.Show(res);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;

            if (!String.IsNullOrEmpty(username) && !@String.IsNullOrEmpty(password))
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey subKey = key.CreateSubKey(@"Software\th7\EastNetLogin");
                subKey.SetValue("username", username);
                subKey.SetValue("password", password);
                subKey.Close();
            }
            else
            {
                MessageBox.Show("用户名和密码不得为空");
            }

        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 25);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(57, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(333, 25);
            this.textBox2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(330, 119);
            this.button1.TabIndex = 2;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(405, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 64);
            this.button2.TabIndex = 3;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(621, 304);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EasyNetLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}