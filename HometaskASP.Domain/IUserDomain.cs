using HomataskASP.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HometaskASP.Domain
{
    public interface IUserDomain
    {
        public DBUser Add(DBUser user);

        public DBUser Remove(DBUser user);

        public DBUser Update(DBUser user);

        public List<DBUser> GetAll();
    }
}
