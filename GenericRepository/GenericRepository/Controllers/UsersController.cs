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
        private readonly Interfaces.IUnitOfWork _unitOfWork;
        public UsersController(Interfaces.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.UserRepository.GetAll();
            return new JsonResult(users);

        }
        [HttpPost]
        public IActionResult Insert([FromBody]Models.User user)
        {
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Complete();
            return new JsonResult(user);
        }
        
    }
}