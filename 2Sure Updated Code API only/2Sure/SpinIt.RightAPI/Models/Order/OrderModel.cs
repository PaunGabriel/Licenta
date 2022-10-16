using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spinit.Data.Models
{
    
    public class OrderModel
    {

        public int PurchaseOrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? OrderTotal { get; set; }
        public string UserID { get; set; }
        public double? GrossTotal { get; set; }
        public int? InvoiceNumber { get; set; }
        public string PaymentStatus { get; set; }
        public int? status { get; set; }
        public bool? IsActive { get; set; }
        public List<OrderDetailModel> OrderDetail { get; set; }
    }

    public class OrderDetailModel
    {   
        public int OrderDetailID { get; set; }

        public int OrdersPurchaseOrderID { get; set; }        
        public int ProductId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string UserId { get; set; }        
        public decimal? Amount { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public bool? IsActive { get; set; }
        public string Remarks { get; set; }

    }

}
