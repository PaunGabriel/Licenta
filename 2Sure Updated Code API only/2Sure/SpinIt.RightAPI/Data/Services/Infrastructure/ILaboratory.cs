using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Infrastructure
{
    public interface ILaboratory
    {
        IEnumerable<Laboratory> GetAll();

        Laboratory GetByID(int id);

        void Insert(Laboratory P);

        void Delete(int id);

        void Update(Laboratory P);

        void Save();

        int Count();
    }
}
