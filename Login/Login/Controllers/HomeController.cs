using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Dto;
using Login.Interfaces;
using Login.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
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

            List<Entry> l = _IUnitOfWork.EntryRepository.GetAll();
            return View(l);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult InsertEntry()
        {

            if (HttpContext.Session.GetInt32("userId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        public IActionResult LoginAction([FromBody]LoginDto loginDto)
        {           
            
            User user = _IUnitOfWork.GetDataContext().Users.SingleOrDefault(a =>
                a.Username == loginDto.Username && a.Password == loginDto.Password);

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

        public IActionResult EntryInputAction([FromBody]DataDto dataDto)
        {
            Entry entry = new Entry();
            entry.Title = dataDto.Title;
            entry.Content = dataDto.Content;

            _IUnitOfWork.EntryRepository.Insert(entry);
            _IUnitOfWork.Complete();

            return new JsonResult("ok");
           
        }
    }
}