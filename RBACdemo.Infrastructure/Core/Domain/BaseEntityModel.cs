using System;

namespace RBACdemo.Infrastructure.Core.Domain
{
    #region  Entity Models
    public class BaseEntityModel 
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDisbalbed { get; set; }
        public bool IsDeleted { get; set; }
    }
    #endregion

}
