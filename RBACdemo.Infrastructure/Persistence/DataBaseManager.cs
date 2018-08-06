using RBACdemo.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure
{
    public class DataBaseManager : IDataBaseManager
    {
        public string GetDataBaseName(string tenantId)
        {
            return $"ApplicationDB-{tenantId.Trim()}";
        }
    }
}
