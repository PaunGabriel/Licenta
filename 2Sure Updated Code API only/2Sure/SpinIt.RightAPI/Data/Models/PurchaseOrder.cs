using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spinit.Data.Models
{
    [Table("Order")]
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [ScaffoldColumn(false)]
        public int PurchaseOrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double? OrderTotal { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double? GrossTotal { get; set; }
        public int? InvoiceNumber { get; set; }
        public string PaymentStatus { get; set; }
        public int? status { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }       

    }
}
