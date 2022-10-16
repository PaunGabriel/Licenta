using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class GroupRepository : IGroup
    {
        private readonly ApplicationDbContext _db;


        public GroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Groups.Count();
        }

        public void Delete(int id)
        {
            var group = GetByID(id);
            if (group != null)
            {
                _db.Groups.Remove(group);
            }
        }

        public IEnumerable<Group> GetAll()
        {
            return _db.Groups.Select(x => x);
        }

        public Group GetByID(int id)
        {
            return _db.Groups.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(Group g)
        {
            _db.Groups.Add(g);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Group g)
        {
            var _group = _db.Groups.FirstOrDefault(m => m.Id == g.Id);
            if (_group != null)
            {
                _group.SpecializationId = g.SpecializationId;
                _group.GroupName =g.GroupName;
                _group.Description = g.Description;
                _group.IsActive = g.IsActive;
            }

        }
    }
}
