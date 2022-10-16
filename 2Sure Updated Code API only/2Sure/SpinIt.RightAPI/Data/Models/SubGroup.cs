using System;

namespace Spinit.Data.Models
{
    public class SubGroup
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public string  SubGroupName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
