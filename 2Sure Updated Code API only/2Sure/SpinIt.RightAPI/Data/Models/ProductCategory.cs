using System;
using System.Collections.Generic;

namespace Spinit.Data.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }

    }
}
