using Microsoft.Toolkit.Uwp.Notifications;
using System;

namespace EasyNetLogin
{
    internal class Login
    {
        public static String login(String IP,String username,String pwd) {
            string url = "http://218.195.105.234:801/eportal/portal/login?callback=dr1004&login_method=1&user_account=,0,"+username+"&user_password="+pwd+"&wlan_user_ip="+IP+"&wlan_user_ipv6=&wlan_user_mac=000000000000&wlan_ac_ip=&wlan_ac_name=&jsVersion=4.1.3&terminal_type=1&lang=zh-cn&lang=zh&v=9797";
            string res = HttpUtils.GetHttpResponse(url, 10000);
            if (res.Contains("认证成功") || res.Contains("已经在线"))
            {
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddText("校园网认证成功")
                    .Show
                    (toast =>
                    {
                        toast.ExpirationTime = DateTime.Now.AddSeconds(5);
                    });
            }
            return res;
        }
    }
}
