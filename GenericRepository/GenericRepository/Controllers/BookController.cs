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
        private readonly Interfaces.IBookRepositorycs _bookRepositorycs;
        
        public BookController(Interfaces.IBookRepositorycs bookRepositorycs)
        {
            _bookRepositorycs = bookRepositorycs;       
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_bookRepositorycs.GetAll());
        }
    }
}