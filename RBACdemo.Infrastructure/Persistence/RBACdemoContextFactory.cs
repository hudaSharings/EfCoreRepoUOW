using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using RBACdemo.Core.Persistence;
using RBACdemo.Core.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RBACdemo.Infrastructure.Persistence
{
    public class RBACdemoContextFactory :IContextFactory
    {
        private const string TenantIdFieldName = "tenantid";
        private const string DatabaseFieldKeyword = "Database";
        private readonly HttpContext httpContext;
        private readonly ConnectionSetting connectionOptions;
        private readonly IDataBaseManager dataBaseManager;
        public RBACdemoContextFactory(ConnectionSetting connectionOptions, IDataBaseManager dataBaseManager, IHttpContextAccessor httpContentAccessor)
        {
            this.httpContext = httpContentAccessor.HttpContext;
            this.connectionOptions = connectionOptions;
            this.dataBaseManager = dataBaseManager;
        }

        public DbContext DbContext => new RBACdemoContext(ChangeDatabaseNameInConnectionString().Options);

        private string TenantId
        {
            get
            {
                ValidateHttpContext();

                string tenantId = this.httpContext.Request.Headers[TenantIdFieldName].ToString();

                ValidateTenantId(tenantId);

                return tenantId;
            }
        }
        private void ValidateDefaultConnection()
        {
            if (string.IsNullOrEmpty(this.connectionOptions.DefaultConnection))
            {
                throw new ArgumentNullException(nameof(this.connectionOptions.DefaultConnection));
            }
        }

        private void ValidateHttpContext()
        {
            if (this.httpContext == null)
            {
                throw new ArgumentNullException(nameof(this.httpContext));
            }
        }
        private static void ValidateTenantId(string tenantId)
        {
            if (tenantId == null)
            {
                throw new ArgumentNullException(nameof(tenantId));
            }
        }
        public DbContextOptionsBuilder<RBACdemoContext> ChangeDatabaseNameInConnectionString()
        {
            ValidateDefaultConnection();

            // 1. Create Connection String Builder using Default connection string
            var sqlConnectionBuilder = new SqlConnectionStringBuilder(this.connectionOptions.DefaultConnection);

            // 2. Remove old Database Name from connection string
            sqlConnectionBuilder.Remove(DatabaseFieldKeyword);

            // 3. Obtain Database name from DataBaseManager and Add new DB name to 
            sqlConnectionBuilder.Add(DatabaseFieldKeyword, this.dataBaseManager.GetDataBaseName(this.TenantId));

            // 4. Create DbContextOptionsBuilder with new Database name
            var contextOptionsBuilder = new DbContextOptionsBuilder<RBACdemoContext>();

            contextOptionsBuilder.UseSqlServer(sqlConnectionBuilder.ConnectionString);

            return contextOptionsBuilder;
        }

       
    }
}
