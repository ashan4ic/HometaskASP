using HomataskASP.DataAccess.Models;
using System.Linq;

namespace HometaskASP.Domain
{
    public interface IUserDomain
    {
        public DbUser Add(DbUser user);

        public bool Remove(DbUser user);

        public DbUser Update(DbUser user);

        public IQueryable<DbUser> Get();
    }
}
