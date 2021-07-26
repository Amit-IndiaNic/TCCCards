using System;

namespace TCCCards.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    public abstract class BaseAuditableEntity : BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public abstract class BaseStatusEntity : BaseAuditableEntity
    {
        public bool IsActive { get; set; }
    }
}
