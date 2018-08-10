using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Core.Domain
{
   public class Tenant:BaseEntityModel
    {
        public int TenantNo { get; set; }
        public string DomainName { get; set; }
        public string Companyname { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime Todate { get; set; }
    }
}
