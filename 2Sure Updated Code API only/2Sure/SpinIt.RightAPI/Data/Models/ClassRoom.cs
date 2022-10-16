using System;
using System.Collections.Generic;

namespace Spinit.Data.Models
{
    public class ClassRoom
    {
        public ClassRoom()
        {
        }
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }

    }
}
