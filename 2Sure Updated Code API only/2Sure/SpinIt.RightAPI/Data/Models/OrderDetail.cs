using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Models
{
        
        public class OrderDetail
        {
            [ScaffoldColumn(false)]
            public int OrderDetailID { get; set; }
            public int ProductId { get; set; }
            public DateTime? TransactionDate { get; set; }
            public string UserId { get; set; }
            public virtual ApplicationUser User { get; set; }
            [Range(1, 100, ErrorMessage = "Price must be between 1 and 100")]
            [Column(TypeName = "decimal(18,4)")]
            public decimal? Amount { get; set; }
            public int? Quantity { get; set; }
            public int? Status { get; set; }
            public bool? IsActive { get; set; }
            public int? OrdersPurchaseOrderID { get; set; }
            public int? OrderID { get; set; }
            public virtual PurchaseOrder Orders { get; set; }
            public virtual Product Products { get; set; }            
            public string Remarks { get; set; }


    }   
}
