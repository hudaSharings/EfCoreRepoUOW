using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Core.Settings
{
   public class JwtSetting
    {
        public static string Audience { get; set; }
        public static string Issuer { get; set; }
        public static string  SecreteKey { get; set; }
        public static int ExpairesInMinutes { get; set; }

    }
}
