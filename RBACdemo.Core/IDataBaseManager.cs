using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Core
{
   public interface IDataBaseManager
    {
        string GetDataBaseName(string tenantId);
    }
}
