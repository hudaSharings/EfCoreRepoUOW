using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Core.Persistence
{
   public interface IDataBaseManager
    {
        string GetDataBaseName(string tenantId);
    }
}
