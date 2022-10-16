using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Infrastructure
{
    public interface IGroup
    {
        IEnumerable<Group> GetAll();

        Group GetByID(int id);

        void Insert(Group P);

        void Delete(int id);

        void Update(Group P);

        void Save();

        int Count();
    }
}
