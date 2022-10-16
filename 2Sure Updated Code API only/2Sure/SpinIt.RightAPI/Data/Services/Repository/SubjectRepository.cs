using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class SubjectRepository : ISubject
    {
        private readonly ApplicationDbContext _db;


        public SubjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Subjects.Count();
        }

        public void Delete(int id)
        {
            var subject = GetByID(id);
            if (subject != null)
            {
                _db.Subjects.Remove(subject);
            }
        }

        public IEnumerable<Subject> GetAll()
        {
            return _db.Subjects.Select(x => x);
        }

        public Subject GetByID(int id)
        {
            return _db.Subjects.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(Subject s)
        {
            _db.Subjects.Add(s);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Subject s)
        {
            var _subject = _db.Subjects.FirstOrDefault(m => m.Id == s.Id);
            if (_subject != null)
            {
                _subject.SpecializationId = s.SpecializationId;
                _subject.TeacherId = s.TeacherId;
                _subject.ClassRoomId = s.ClassRoomId;
                _subject.Name = s.Name;
                _subject.Description = s.Description;
                _subject.IsActive = s.IsActive;
            }

        }
    }
}
