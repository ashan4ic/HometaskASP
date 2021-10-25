using HomataskASP.DataAccess;
using HomataskASP.DataAccess.Models;
using System.Linq;

namespace HometaskASP.Domain
{
    public class UserDomain : IUserDomain
    {
        private readonly DataContext _db;

        public UserDomain(DataContext dataContext)
        {
            _db = dataContext;
        }

        public DbUser Add(DbUser user)
        {
            if (user == null)
            {
                return null;
            }

            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public bool Remove(DbUser user)
        {
            if (user == null)
            {
                return true;
            }

            _db.Users.Remove(user);
            return _db.SaveChanges() != 0;
        }

        public IQueryable<DbUser> Get()
        {
            return _db.Users.AsQueryable();
        }

        public DbUser Update(DbUser user)
        {
            if (user == null)
            {
                return null;
            }

            var upUser = _db.Users.Update(user);

            return _db.SaveChanges() != 0 ? upUser.Entity : null;
        }
    }
}
