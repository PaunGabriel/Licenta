using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Infrastructure
{
    public interface IClassRoom
    {
        IEnumerable<ClassRoom> GetAll();

        ClassRoom GetByID(int id);

        void Insert(ClassRoom cr);

        void Delete(int id);

        void Update(ClassRoom cr);

        void Save();

        int Count();
    }
}
