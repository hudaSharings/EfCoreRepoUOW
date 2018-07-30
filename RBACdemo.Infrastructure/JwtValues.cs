using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure
{
   public class JwtValues
    {
        public static string Audience { get; set; }
        public static string Issuer { get; set; }
        public static string  SecreteKey { get; set; }
        public static int ExpairesInMinutes { get; set; }

    }
}
