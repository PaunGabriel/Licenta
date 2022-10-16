using Microsoft.EntityFrameworkCore;
using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using Spinit.Data.Servicess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Spinit.Data.Services.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrder
    {
        private readonly ApplicationDbContext _db;

        public PurchaseOrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.OrderDetail.Count();
        }

        public void Delete(int id)
        {
            var order = GetByID(id);
            if (order != null)
            {
                _db.Order.Remove(order);
            }
        }

        public IEnumerable<PurchaseOrder> GetAll()
        {
            return _db.Order.ToList<PurchaseOrder>();
        }

        /// <returns></returns>
        //public IEnumerable<DataAccess.Model.InvoiceDetail> GetInvoiceDetails(Expression<Func<DataAccess.Model.InvoiceDetail, bool>> where, bool noTracking=false)
        //{
        //    if (@where == null) throw new ArgumentException("where");
        //    return _invoicedetailRepository.GetMany(where, noTracking);

        //}
        public PurchaseOrder GetByID(int id)
        {
            return _db.Order.FirstOrDefault
               (x => x.PurchaseOrderID == id);
        }

        public void Insert(PurchaseOrder PO)
        {
            _db.Order.Add(PO);
        }		


        public void Save()
        {
            _db.SaveChanges();
        }


        public void Update(PurchaseOrder PO)
        {

            var _PO = _db.Order.FirstOrDefault(m => m.PurchaseOrderID == PO.PurchaseOrderID);
            if (_PO != null)
            {
                _PO.OrderDate = PO.OrderDate;
                _PO.InvoiceNumber = PO.InvoiceNumber;
                _PO.PaymentStatus = PO.PaymentStatus;
                _PO.status = PO.status;
                _PO.OrderTotal = PO.OrderTotal;
                _PO.GrossTotal = PO.GrossTotal;
                
            }
        }

    }
}
