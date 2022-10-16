using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class LaboratoryRepository : ILaboratory
    {
        private readonly ApplicationDbContext _db;


        public LaboratoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Laboratories.Count();
        }

        public void Delete(int id)
        {
            var laboratory = GetByID(id);
            if (laboratory != null)
            {
                _db.Laboratories.Remove(laboratory);
            }
        }

        public IEnumerable<Laboratory> GetAll()
        {
            return _db.Laboratories.Select(x => x);
        }

        public Laboratory GetByID(int id)
        {
            return _db.Laboratories.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(Laboratory l)
        {
            _db.Laboratories.Add(l);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Laboratory l)
        {
            var _labortory = _db.Laboratories.FirstOrDefault(m => m.Id == l.Id);
            if (_labortory != null)
            {
                _labortory.SubGroupId = l.SubGroupId;
                _labortory.LaboratoryName =l.LaboratoryName;
                _labortory.Description = l.Description;
                _labortory.IsActive = l.IsActive;
            }

        }
    }
}
