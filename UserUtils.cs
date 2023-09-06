using Microsoft.Win32;
using System;

namespace EasyNetLogin
{
    internal class UserUtils
    {
        public static String GetUserName()
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey subKey = key.OpenSubKey(@"Software\th7\EastNetLogin");
            if (subKey != null)
            {
                string value = subKey.GetValue("username") as string;
                subKey.Close();
                return value;
            } else
            {
                return null;
            }
        }
        public static String GetPassword()
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey subKey = key.OpenSubKey(@"Software\th7\EastNetLogin");
            if (subKey != null)
            {
                string value = subKey.GetValue("password") as string;
                subKey.Close();
                return value;
            }
            else
            {
                return null;
            }
        }
    }
}
