using Microsoft.AspNetCore.Mvc;
using System;
using HometaskASP.Models;
using HometaskASP.Services;
using HometaskASP.Services.Models;

namespace HometaskASP.Controllers
{
    public class HomeController : Controller
    {        
        private readonly IUsersService _usersService;
        public HomeController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] RequestUser request)
        {
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
            return Ok(_usersService.Get());
        }

        [Route("get/{page}/{count}")]
        [HttpGet]
        public IActionResult Get(int page, int count)
        {
            return Ok(_usersService.Get(page, count));
        }

        [Route("delete/{Id}")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            if (!_usersService.Delete(id))
            {
                return StatusCode(500);
            }

            return Ok($"пользователь {id} удален");
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Put([FromBody] UpdateUser update)
        {
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
