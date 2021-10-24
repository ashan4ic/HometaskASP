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
        private readonly IUsersService _usersService;
        public HomeController(DataContext dataContext, IUsersService usersService)
        {
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
                Name = request.Name,
                Age = request.Age
            });

            if (id == Guid.Empty)
            {
                return new StatusCodeResult(500);
            }

            return Ok($"Создан пользователь с id {id}");
        }

        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usersService.GetAll());
        }

        [Route("get/{page}/{count}")]
        [HttpGet]
        public IActionResult Get(int page, int count)
        {
            return Ok(_usersService.GetAll(page, count));
        }

        [Route("delete/{Id}")]
        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            var delUser = _usersService.Delete(Id);
            return Ok($"пользователь {delUser.Name} удален");
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Put([FromBody] UpdateUser update)
        {
            if (update == null)
            {
                return BadRequest();
            }
            var id = _usersService.Put(new UserModel
            {
                Id = update.Id,
                Name = update.Name,
                Age = update.Age
            });

            if (id == Guid.Empty)
            {
                return new StatusCodeResult(500);
            }

            return Ok($"Пользователь {id} обновлён");
        }
    }
}
