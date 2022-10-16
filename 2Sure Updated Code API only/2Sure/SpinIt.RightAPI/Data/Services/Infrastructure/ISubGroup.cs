using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Infrastructure
{
    public interface ISubGroup
    {
        IEnumerable<SubGroup> GetAll();

        SubGroup GetByID(int id);

        void Insert(SubGroup P);

        void Delete(int id);

        void Update(SubGroup P);

        void Save();

        int Count();
    }
}
