using System;

namespace Spinit.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int? ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public string ArticalNumber { get; set; }
        public string  ProductName { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public bool? IsActive { get; set; }

    }
}
