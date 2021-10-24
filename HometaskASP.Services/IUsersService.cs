using HometaskASP.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HometaskASP.Services
{
    public interface IUsersService
    {
        public Guid CreateUser(UserModel user);

        public List<UserModel> GetAll();

        public List<UserModel> GetAll(int page, int count);

        public UserModel Delete(Guid Id);

        public Guid Put(UserModel user);
    }
}
