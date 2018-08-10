using RBACdemo.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence
{
    public class DataBaseManager : IDataBaseManager
    {
        public string GetDataBaseName(string tenantId)
        {
            // return $"ApplicationDB-{tenantId.Trim()}";
            return tenantId;
        }
    }
}
