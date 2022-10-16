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
    public class OrderDetailRepository:IOrderDetail
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.OrderDetail.Count();
        }

        public void Delete(int id)
        {
            var orderDetail = GetByID(id);
            if (orderDetail != null)
            {
                _db.OrderDetail.Remove(orderDetail);
            }
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _db.OrderDetail.ToList();
        }

        /// <returns></returns>
        //public IEnumerable<DataAccess.Model.InvoiceDetail> GetInvoiceDetails(bool noTracking=false)
        //{
        //    return _invoicedetailRepository.GetAll(noTracking);
        //}

        public OrderDetail GetByID(int id)
        {
            return _db.OrderDetail.FirstOrDefault
               (x => x.OrderDetailID == id);
        }

        public void Insert(OrderDetail OD)
        {
            _db.OrderDetail.Add(OD);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(OrderDetail OD)
        {

            var _OD = _db.OrderDetail.FirstOrDefault(m => m.OrderDetailID == OD.OrderDetailID);
            if (_OD != null)
            {
                _OD.ProductId = OD.ProductId;
                _OD.Amount = OD.Amount;
                _OD.Quantity = OD.Quantity;
                _OD.Remarks = OD.Remarks;

            }
        }
    }
}
