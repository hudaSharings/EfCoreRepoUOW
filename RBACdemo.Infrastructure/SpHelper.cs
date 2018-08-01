using Microsoft.EntityFrameworkCore;
using RBACdemo.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using RBACdemo.Utility;
namespace RBACdemo.Infrastructure
{
    public class SpHelper
    {
        DbContext _dbContext;
        SqlConnection sqlConn;
        public SpHelper(IContextFactory context)
        {
            _dbContext = context.DbContext;
            sqlConn = (SqlConnection)_dbContext.Database.GetDbConnection();
        }

        public List<T> Execute<T>(string spname, object param=null) where T : new()
        {
            //To be implemented later
            string qry = spname;
            return GetDataSet(qry).Tables[0].ToList<T>();
        }

        private DataSet GetDataSet(string qryStr)
        {
            DataSet retDs = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(qryStr);
                cmd.Connection = sqlConn;
                SqlDataAdapter daSql = new SqlDataAdapter(cmd);
                using (cmd)
                {
                    daSql.Fill(retDs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retDs;
        }
    }
}
