using System;

namespace Spinit.Data.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int? SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        public string  GroupName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
