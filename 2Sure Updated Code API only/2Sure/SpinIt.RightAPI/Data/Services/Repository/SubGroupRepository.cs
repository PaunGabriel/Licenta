using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class SubGroupRepository : ISubGroup
    {
        private readonly ApplicationDbContext _db;


        public SubGroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.SubGroups.Count();
        }

        public void Delete(int id)
        {
            var subgroup = GetByID(id);
            if (subgroup != null)
            {
                _db.SubGroups.Remove(subgroup);
            }
        }

        public IEnumerable<SubGroup> GetAll()
        {
            return _db.SubGroups.Select(x => x);
        }

        public SubGroup GetByID(int id)
        {
            return _db.SubGroups.FirstOrDefault
                    (x => x.Id == id);
        }

        public void Insert(SubGroup g)
        {
            _db.SubGroups.Add(g);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(SubGroup sg)
        {
            var _subgroup = _db.SubGroups.FirstOrDefault(m => m.Id == sg.Id);
            if (_subgroup != null)
            {
                _subgroup.GroupId = sg.GroupId;
                _subgroup.SubGroupName =sg.SubGroupName;
                _subgroup.Description = sg.Description;
                _subgroup.IsActive = sg.IsActive;
            }
            
        }
    }
}
