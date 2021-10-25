using HomataskASP.DataAccess.Models;
using HometaskASP.Domain;
using HometaskASP.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var dbUser = _userDomain.Add(new DbUser
            {
                Name = user.Name,
                Age = user.Age
            });

            return dbUser?.Id ?? Guid.Empty;
        }

        public List<UserModel> Get()
        {
            return _userDomain.Get()
                .Select(x => new UserModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age
                })
                .ToList();
        }

        public List<UserModel> Get(int page, int count)
        {
            return _userDomain.Get()
                .OrderBy(x => x.Id)
                .Skip((page - 1) * count)
                .Take(count)
                .Select(x => new UserModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age
                })
                .ToList();
        }

        public bool Delete(Guid Id)
        {
            DbUser delUser = _userDomain.Get().FirstOrDefault(x => x.Id == Id);

            if (delUser == null) 
            {
                return true;
            }

            return _userDomain.Remove(delUser);
        }

        public Guid Put(UserModel user)
        {
            if (user == null)
            {
                return Guid.Empty;
            }

            var dbUser = _userDomain.Get().FirstOrDefault(x => x.Id == user.Id);

            if (dbUser == null)
            {
                return Guid.Empty;
            }

            dbUser.Name = user.Name;
            dbUser.Age = user.Age;

            return _userDomain.Update(dbUser)?.Id ?? Guid.Empty;
        }
    }
}
