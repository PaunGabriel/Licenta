using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spinit.Data.Services.Infrastructure
{
   public interface IApplicationUser
    {
        IEnumerable<ApplicationUser> GetAll();

        //ApplicationUser GetByID(string id);
        void Delete(string Id);
        void Update(ApplicationUser P);
        void Save();
        int Count();
    }
}
