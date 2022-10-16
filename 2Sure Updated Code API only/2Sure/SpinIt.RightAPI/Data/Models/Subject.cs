using System;

namespace Spinit.Data.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int? ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public int? SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

    }
}
