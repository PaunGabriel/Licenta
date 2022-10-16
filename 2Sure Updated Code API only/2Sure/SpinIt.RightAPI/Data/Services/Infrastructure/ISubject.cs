using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Infrastructure
{
    public interface ISubject
    {
        IEnumerable<Subject> GetAll();

        Subject GetByID(int id);

        void Insert(Subject s);

        void Delete(int id);

        void Update(Subject s);

        void Save();

        int Count();
    }
}
