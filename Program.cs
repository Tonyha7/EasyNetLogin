using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Windows.Forms;

namespace EasyNetLogin
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            bool isNeedLoadForm = false;
            
            string[] commandLineArgs = Environment.GetCommandLineArgs();

            for (int i = 0; i < commandLineArgs.Length; i++)
            {
                if (commandLineArgs[i] == "-f")
                {
                    isNeedLoadForm = true;
                }
            }
            
            IP.initLocalIP();

            if (String.IsNullOrEmpty(IP.localIP))
            {
                new ToastContentBuilder()
                   .AddArgument("action", "viewConversation")
                   .AddText("获取局域网IP失败")
                   .Show
                   (toast =>
                   {
                       toast.ExpirationTime = DateTime.Now.AddSeconds(5);
                   });
            }

            String username = UserUtils.GetUserName();
            String password = UserUtils.GetPassword();

            if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(password))
            {
                isNeedLoadForm = true;
            }

            if (!isNeedLoadForm) {
                Login.login(IP.localIP, username, password);
            } else
            {
                LoadForm();
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
