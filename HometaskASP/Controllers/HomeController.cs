using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomataskASP.DataAccess;
using HomataskASP.DataAccess.Models;
using HometaskASP.Models;
using HometaskASP.Services;
using HometaskASP.Services.Models;

namespace HometaskASP.Controllers
{
    public class HomeController : Controller
    {        
        private readonly DataContext db;
        private readonly IUsersService _usersService;
        public HomeController(DataContext dataContext, IUsersService usersService)
        {
            db = dataContext;
            _usersService = usersService;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult SomePing([FromBody] RequestUser request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var id = _usersService.CreateUser(new UserModel
            {
                Name = request.name,
                Age = request.age
            });

            if (id == Guid.Empty)
            {
                return new StatusCodeResult(500);
            }

            return Ok($"Создан пользователь с id {id}");
        }

        [Route("get")]
        public IActionResult Get()
        {
            return Ok(db.Users.ToList());
        }
    }
}
