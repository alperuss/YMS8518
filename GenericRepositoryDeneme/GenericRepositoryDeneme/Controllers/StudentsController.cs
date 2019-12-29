using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryDeneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Interfaces.IUnitOfWork _unitOfWork;
        public StudentsController(Interfaces.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _unitOfWork.StudentRepository.GetAll();
            return new JsonResult(students);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var students = _unitOfWork.StudentRepository.GetById(id);
            return new JsonResult(students);
        }
        [HttpPost]
        public IActionResult Insert([FromBody]Models.Student student)
        {
            _unitOfWork.StudentRepository.Insert(student);
            _unitOfWork.Complete();
            return new JsonResult(student);
        }
        [HttpPut]
        public IActionResult Update([FromBody]Models.Student student)
        {
            _unitOfWork.StudentRepository.Update(student);
            _unitOfWork.Complete();
            return new JsonResult(student);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.StudentRepository.Delete(id);
            _unitOfWork.Complete();
            return Ok();
        }
      
    }
}