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
    public class PetsController : ControllerBase
    {
        private readonly Interfaces.IPetRepository _petRepository;
        public PetsController(Interfaces.IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_petRepository.GetAll());
        }
    }
}