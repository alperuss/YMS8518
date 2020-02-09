using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatLogin.Dto;
using ChatLogin.Interfaces;
using ChatLogin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ChatLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;

        public HomeController(IUnitOfWork iUnitOfWork)
        {
            _IUnitOfWork = iUnitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Chat()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if (userId == null)
            {
                return Unauthorized();
            }
            var user = _IUnitOfWork.UserRepository.GetById((int)userId);
            return View(user);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignAction([FromBody]UserDto userDto)
        {
            User user = new User();
            user.Username = userDto.Username;
            user.Password = userDto.Password;

            _IUnitOfWork.UserRepository.Insert(user);
            _IUnitOfWork.Complete();

            return new JsonResult("ok");

        }
        public IActionResult LoginAction([FromBody]UserDto userDto)
        {

            User user = _IUnitOfWork.GetDataContext().Users.SingleOrDefault(a =>
                a.Username == userDto.Username && a.Password == userDto.Password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("userId", user.Id);
                return new JsonResult("OK");
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}