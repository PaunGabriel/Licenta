using Spinit.Data.Models;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spinit.Data.Services.Repository
{
    public class ApplicationUserRepository : IApplicationUser
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.User.Count();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _db.User.ToList();
        }

        public ApplicationUser GetByID(string id)
        {
            return _db.User.FirstOrDefault(m => m.Id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Delete(string id)
        {
            var product = GetByID(id);
            if (product != null)
            {
                _db.User.Remove(product);
            }
        }

        public void Update(ApplicationUser user)
        {
            var _user = _db.User.FirstOrDefault(m => m.Id == user.Id);
            if (_user!= null)
            {
                _user.Email = user.Email;
                _user.FirstNames = user.FirstNames;
                _user.LastName = user.LastName;
                _user.Mobile = user.Mobile;
                _user.UserName = user.UserName;
            }
        }
        
    }
}
