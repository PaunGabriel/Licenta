using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class SeminarRepository : ISeminar
    {
        private readonly ApplicationDbContext _db;


        public SeminarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Seminars.Count();
        }

        public void Delete(int id)
        {
            var seminar = GetByID(id);
            if (seminar != null)
            {
                _db.Seminars.Remove(seminar);
            }
        }

        public IEnumerable<Seminar> GetAll()
        {
            return _db.Seminars.Select(x => x);
        }

        public Seminar GetByID(int id)
        {
            return _db.Seminars.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(Seminar g)
        {
            _db.Seminars.Add(g);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Seminar s)
        {
            var _seminar = _db.Seminars.FirstOrDefault(m => m.Id == s.Id);
            if (_seminar != null)
            {
                _seminar.GroupId = s.GroupId;
                _seminar.SeminarName =s.SeminarName;
                _seminar.Description = s.Description;
                _seminar.IsActive = s.IsActive;
            }

        }
    }
}
