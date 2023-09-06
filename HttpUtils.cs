using System.IO;
using System.Net;
using System.Text;

namespace EasyNetLogin
{
    internal class HttpUtils
    {
        public static string GetHttpResponse(string url, int Timeout)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.ContentType = "text/html;charset=UTF-8";
            req.UserAgent = null;
            req.Timeout = Timeout;

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Stream resS = res.GetResponseStream();
            StreamReader SR = new StreamReader(resS, Encoding.GetEncoding("utf-8"));
            string retString = SR.ReadToEnd();
            SR.Close();
            resS.Close();

            return retString;
        }
    }
}
