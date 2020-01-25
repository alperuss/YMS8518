using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        [HttpGet]
        public IActionResult Insert()
        {
            Models.User user = new Models.User()
            {
                Username="username",
                Password="1234"
            };
            _dataContext.Users.Add(user);

            Models.Personal personal = new Models.Personal()
            {
                Name = "salla",
                Surname = "sallama",
                UserId=user.Id

            };
            _dataContext.Personals.Add(personal);
            _dataContext.SaveChanges();
            return new JsonResult("ok");
        }
        [HttpGet("2")]
        public IActionResult Insert2()
        {
            var user = _dataContext.Users.Last();
            var address = new Models.Address() {
                OpenAddress="açık adres",
                User=user
            };
            _dataContext.Addresses.Add(address);
            _dataContext.SaveChanges();
            return new JsonResult(user);
            
        }
    }
}