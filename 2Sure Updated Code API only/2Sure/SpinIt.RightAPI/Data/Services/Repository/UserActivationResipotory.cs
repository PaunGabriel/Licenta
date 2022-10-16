using Spinit.Data;
using Spinit.Data.Models;
using Spinit.Data.Servicess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    public class UserActivationResipotory : UserActivation
    {
        private readonly ApplicationDbContext _db;

        public UserActivationResipotory(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Delete(string Userid)
        {
            var cu = GetByID(Userid);
            if (cu != null)
            {
                _db.UserActivation.Remove(cu);
            }
        }

        public UserActivation GetByID(string Userid)
        {
            return _db.UserActivation.FirstOrDefault(x => x.UserID == Userid);
        }

        public void Insert(UserActivation ca)
        {
            _db.UserActivation.Add(ca);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
