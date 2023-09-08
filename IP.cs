using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture;

namespace EasyNetLogin
{
    public class IP
    {
        public static String localIP = String.Empty;

        public static void initLocalIP()
        {
            IPAddress LocalIP = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily.ToString().Equals("InterNetwork")).FirstOrDefault();
            if (LocalIP != null)
            {
                localIP = LocalIP.ToString();
            } else
            {
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddText("获取局域网IP失败")
                    .Show
                    (toast =>
                    {
                        toast.ExpirationTime = DateTime.Now.AddSeconds(5);
                    });
                localIP = "";
            }
        }
    }
}
