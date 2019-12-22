using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Interfaces.IBookRepository _bookRepository;
        public BooksController(Interfaces.IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Models.Book> books = _bookRepository.List();

            return new JsonResult(books);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Models.Book book = _bookRepository.Get(id);
            return new JsonResult(book);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] Models.Book book)
        {
            _bookRepository.Insert(book);
            return new JsonResult(book);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Models.Book book)
        {
            _bookRepository.Update(book);
            return new JsonResult(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookRepository.Delete(id);
            return Ok();

        }






    }
}