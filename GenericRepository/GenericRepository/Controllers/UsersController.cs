using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Interfaces.IUserRepository _userRepository;
        public UsersController(Interfaces.IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userRepository.GetAll();
            return new JsonResult(users);

        }
        
    }
}