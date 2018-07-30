using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Core.Settings
{
  public  class ConnectionSetting
    {
        public ConnectionSetting(string conStr)
        {
            DefaultConnection = conStr;
        }
        public string DefaultConnection { get; set; }
    }
}
