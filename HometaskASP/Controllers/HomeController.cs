using HometaskASP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomataskASP.DataAccess;
using HomataskASP.DataAccess.Models;

namespace HometaskASP.Controllers
{
    public class HomeController : Controller
    {
        DataContext db;
        
        [Route("create")]
        public IActionResult Create(string name, int age)
        {
            DBUser user1 = new DBUser { Name = name, Age = age };

            db.Users.AddRange(user1);
            db.SaveChanges();

            return Ok($"Добавлены в бд {user1.Name}.");
        }
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok(db.Users.ToList());
        }
    }
}
