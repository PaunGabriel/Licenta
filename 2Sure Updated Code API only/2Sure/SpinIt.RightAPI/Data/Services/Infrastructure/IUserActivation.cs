using Spinit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinit.Data.Servicess.Infrastructure
{
    public interface IUserActivation
    {

        UserActivation GetByID(string Userid);

        void Insert(UserActivation ca);

        void Delete(string Userid);

        void Save();

    }
}
