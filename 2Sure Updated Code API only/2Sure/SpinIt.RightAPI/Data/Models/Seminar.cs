using System;

namespace Spinit.Data.Models
{
    public class Seminar
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public string SeminarName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
