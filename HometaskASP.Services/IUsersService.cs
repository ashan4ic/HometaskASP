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
    }
}
