using HomataskASP.DataAccess;
using HomataskASP.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HometaskASP.Domain
{
    public class UserDomain
    {
        private readonly DataContext _db;

        public UserDomain(DataContext dataContext)
        {
            _db = dataContext;
        }

        public DBUser Add(DBUser user)
        {
            if (user == null)
            {
                return null;
            }

            _db.Users.Add(user);

            return _db.SaveChanges() != 0 ? user : null;
        }
    
    }
}
