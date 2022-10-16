using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class SpecializationRepository : ISpecialization
    {
        private readonly ApplicationDbContext _db;


        public SpecializationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Specializations.Count();
        }

        public void Delete(int id)
        {
            var specializations = GetByID(id);
            if (specializations != null)
            {
                _db.Specializations.Remove(specializations);
            }
        }

        public IEnumerable<Specialization> GetAll()
        {
            return _db.Specializations.Select(x => x);
        }

        public Specialization GetByID(int id)
        {
            return _db.Specializations.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(Specialization sp)
        {
            _db.Specializations.Add(sp);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Specialization sp)
        {
            var _specializations = _db.Specializations.FirstOrDefault(m => m.Id == sp.Id);
            if (_specializations != null)
            {
                _specializations.Title = sp.Title;
                _specializations.IsActive = sp.IsActive;
                _specializations.Desciption = sp.Desciption;
            }
        }
    }
}
