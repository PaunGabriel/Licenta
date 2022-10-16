using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Infrastructure
{
    public interface ITeacher
    {
        IEnumerable<Teacher> GetAll();

        Teacher GetByID(int id);

        void Insert(Teacher sp);

        void Delete(int id);

        void Update(Teacher sp);

        void Save();

        int Count();
    }
}
