using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Spinit.Data.Models
{

    public class Teacher
    {
        public Teacher() : base() {            
           // Orders = new HashSet<PurchaseOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }

    
    }
    
}
