using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Infrastructure
{
    public interface ISeminar
    {
        IEnumerable<Seminar> GetAll();

        Seminar GetByID(int id);

        void Insert(Seminar P);

        void Delete(int id);

        void Update(Seminar P);

        void Save();

        int Count();
    }
}
