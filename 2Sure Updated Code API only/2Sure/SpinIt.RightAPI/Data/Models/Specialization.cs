using System;
using System.Collections.Generic;

namespace Spinit.Data.Models
{
    public class Specialization
    {
        public Specialization()
        {
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public bool? IsActive { get; set; }

    }
}
