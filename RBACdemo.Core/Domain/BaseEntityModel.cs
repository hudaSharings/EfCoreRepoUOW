using System;
using System.ComponentModel.DataAnnotations;

namespace RBACdemo.Core.Domain
{
    #region  Entity Models
    public class BaseEntityModel 
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDisbalbed { get; set; }
        public bool IsDeleted { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
    #endregion

}
