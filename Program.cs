using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace EasyNetLogin
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();

            for (int i = 0; i < commandLineArgs.Length; i++)
            {
                if (commandLineArgs[i] == "-f")
                {
                    LoadForm();
                }
            }

            String username = UserUtils.GetUserName();
            String password = UserUtils.GetPassword();
            if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(password))
            {
                LoadForm();
            } else
            {
                IPAddress LocalIP = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily.ToString().Equals("InterNetwork")).FirstOrDefault();
                Login.login(LocalIP.ToString(),username,password);
            }
        }

        static void LoadForm()
        {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
        }
    }
}
