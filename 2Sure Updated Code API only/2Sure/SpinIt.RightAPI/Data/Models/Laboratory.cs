using System;

namespace Spinit.Data.Models
{
    public class Laboratory
    {
        public int Id { get; set; }
        public int? SubGroupId { get; set; }
        public virtual SubGroup SubGroup { get; set; }
        public string LaboratoryName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
