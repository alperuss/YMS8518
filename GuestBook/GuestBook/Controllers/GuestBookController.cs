using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestBook.Data.Context;
using GuestBook.Data.Dto;
using GuestBook.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuestBook.Controllers
{
    public class GuestBookController : Controller
    {
        private readonly DataContext _dataContext;
        public GuestBookController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            List<GuestNote> guestNotes = _dataContext.GuestNotes.ToList();
            return View(guestNotes);
        }
        public IActionResult Manage()
        {
            return View();
        }

        public IActionResult LoginAction([FromBody]GuestBookLoginDto guestBookLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad Boy");
            }
            User user = _dataContext.Users.SingleOrDefault(a =>
              a.Username == guestBookLoginDto.Username && a.Password == guestBookLoginDto.Password);
            if (user !=null)
            {
                HttpContext.Session.SetInt32("userId", user.Id);
                return new JsonResult("OK");

            }
            else
            {
                return Unauthorized();
            }

            if (guestBookLoginDto.Username=="admin" && guestBookLoginDto.Password=="12345678")
            {

            }

            return new JsonResult("ok");
        }
        public IActionResult AdminDashboard()
        {
            if (HttpContext.Session.GetInt32("userId")!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Manage","GuestBook");
            }
            return View();
        }

        public IActionResult SendAction([FromBody]GuestBookSendActionDto guestBookSendActionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Biz de Yapardık zamanında");
            }
            GuestNote guestNote = new GuestNote();
            guestNote.Name = guestBookSendActionDto.Name;
            guestNote.Surname = guestBookSendActionDto.Surname;
            guestNote.Email = guestBookSendActionDto.Email;
            guestNote.Message = guestBookSendActionDto.Message;
            guestNote.CreateDate = DateTime.Now;

            _dataContext.GuestNotes.Add(guestNote);
            _dataContext.SaveChanges();
            return new JsonResult("ok");
        }
    }
}