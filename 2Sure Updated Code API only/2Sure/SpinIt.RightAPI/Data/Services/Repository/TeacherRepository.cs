using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class TeacherRepository : ITeacher
    {
        private readonly ApplicationDbContext _db;


        public TeacherRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Teachers.Count();
        }

        public void Delete(int id)
        {
            var teachers = GetByID(id);
            if (teachers != null)
            {
                _db.Teachers.Remove(teachers);
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _db.Teachers.Select(x => x);
        }

        public Teacher GetByID(int id)
        {
            return _db.Teachers.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(Teacher t)
        {
            _db.Teachers.Add(t);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Teacher t)
        {
            var _teachers = _db.Teachers.FirstOrDefault(m => m.Id == t.Id);
            if (_teachers != null)
            {
                _teachers.Name = t.Name;
                _teachers.IsActive = t.IsActive;
                _teachers.Photo = t.Photo;
                _teachers.Contact = t.Contact;
                _teachers.Email = t.Email;
                _teachers.Address = t.Address;
            }
        }
    }
}
