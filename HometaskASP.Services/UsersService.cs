using HomataskASP.DataAccess.Models;
using HometaskASP.Domain;
using HometaskASP.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HometaskASP.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserDomain _userDomain;

        public UsersService(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }
        public Guid CreateUser(UserModel user)
        {
            var dbUser = _userDomain.Add(new DBUser
            {
                Name = user.Name,
                Age = user.Age
            });

            return dbUser?.Id == null ? Guid.Empty : (Guid)dbUser.Id;
        }

        public List<UserModel> GetAll()
        {
            List<DBUser> newList = _userDomain.GetAll();

            List<UserModel> result = new List<UserModel>();

            foreach (var item in newList)
            {
                result.Add(new UserModel { Id = item.Id, Name = item.Name, Age = item.Age });
            }

            return result;
        }
    }
}
