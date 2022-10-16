using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class ClassRoomRepository : IClassRoom
    {
        private readonly ApplicationDbContext _db;

        public ClassRoomRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.ClassRooms.Count();
        }

        public void Delete(int id)
        {
            var classRooms = GetByID(id);
            if (classRooms != null)
            {
                _db.ClassRooms.Remove(classRooms);
            }
        }

        public IEnumerable<ClassRoom> GetAll()
        {
            return _db.ClassRooms.Select(x => x);
        }

        public ClassRoom GetByID(int id)
        {
            return _db.ClassRooms.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(ClassRoom cr)
        {
            _db.ClassRooms.Add(cr);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ClassRoom cr)
        {
            var _classRooms = _db.ClassRooms.FirstOrDefault(m => m.Id == cr.Id);
            if (_classRooms != null)
            {
                _classRooms.RoomNumber = cr.RoomNumber;
                _classRooms.IsActive = cr.IsActive;
                _classRooms.Floor = cr.Floor;
            }
        }
    }
}
