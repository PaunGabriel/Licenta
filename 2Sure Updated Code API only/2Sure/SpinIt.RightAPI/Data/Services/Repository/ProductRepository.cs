using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _db;


        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Products.Count();
        }

        public void Delete(int id)
        {
            var product = GetByID(id);
            if (product != null)
            {
                _db.Products.Remove(product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products.Select(x => x);
        }

        public Product GetByID(int id)
        {
            return _db.Products.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(Product OL)
        {
            _db.Products.Add(OL);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product OL)
        {
            var _product = _db.Products.FirstOrDefault(m => m.Id == OL.Id);
            if (_product != null)
            {
                _product.ArticalNumber = OL.ArticalNumber;
                _product.ProductCategoryId = OL.ProductCategoryId;
                _product.ProductName = OL.ProductName;
                _product.Price = OL.Price;
                _product.IsActive = OL.IsActive;

            }

        }
    }
}
