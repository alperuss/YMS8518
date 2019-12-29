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
    public class BookController : ControllerBase
    {
        private readonly Interfaces.IUnitOfWork _unitOfWork;
        public BookController(Interfaces.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _unitOfWork.BookRepositorycs.GetAll();
            return new JsonResult(books);

        }
        [HttpPost]
        public IActionResult Insert([FromBody]Models.Book book)
        {
            _unitOfWork.BookRepositorycs.Insert(book);
            _unitOfWork.Complete();
            return new JsonResult(book);
        }
    }