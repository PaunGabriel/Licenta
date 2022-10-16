using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Infrastructure
{
    public interface ISpecialization
    {
        IEnumerable<Specialization> GetAll();

        Specialization GetByID(int id);

        void Insert(Specialization sp);

        void Delete(int id);

        void Update(Specialization sp);

        void Save();

        int Count();
    }
}
