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

        public List<UserModel> GetAll(int page, int count)
        {
            List<DBUser> newList = _userDomain.GetAll();

            List<UserModel> result = new List<UserModel>();

            foreach (var item in newList)
            {
                result.Add(new UserModel { Id = item.Id, Name = item.Name, Age = item.Age });
            }

            return result.OrderBy(x => x.Id).Skip((page - 1) * count).Take(count).ToList();
        }

        public UserModel Delete(Guid Id)
        {
            DBUser delUser = _userDomain.GetAll().FirstOrDefault(x => x.Id == Id);
            
            if (delUser != null) _userDomain.Remove(delUser);

            return new UserModel { Id = Id, Name = delUser.Name, Age = delUser.Age };
        }

        public Guid Put(UserModel user)
        {
            if (user == null)
            {
                return Guid.Empty;
            }
            if (!_userDomain.GetAll().Any(x => x.Id == user.Id))
            {
                return Guid.Empty;
            }

            var UpUser = _userDomain.Update(new DBUser
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age
            });

            return UpUser.Id;
        }
    }
}
