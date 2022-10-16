using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class ProductCategoryRepository : IProductCategory
    {
        private readonly ApplicationDbContext _db;


        public ProductCategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.ProductCategory.Count();
        }

        public void Delete(int id)
        {
            var productCategory = GetByID(id);
            if (productCategory != null)
            {
                _db.ProductCategory.Remove(productCategory);
            }
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _db.ProductCategory.Select(x => x);
        }

        public ProductCategory GetByID(int id)
        {
            return _db.ProductCategory.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(ProductCategory OL)
        {
            _db.ProductCategory.Add(OL);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ProductCategory OL)
        {
            var _productCategory = _db.ProductCategory.FirstOrDefault(m => m.Id == OL.Id);
            if (_productCategory != null)
            {
                _productCategory.Name = OL.Name;
                _productCategory.IsActive = OL.IsActive;
                _productCategory.Remarks = OL.Remarks;

            }
        }
    }
}
