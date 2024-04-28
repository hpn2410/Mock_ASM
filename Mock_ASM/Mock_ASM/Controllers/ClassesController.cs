using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mock_ASM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetAll()
        {
            var classes = await _classService.GetAll();
            return Ok(classes);
        }

        // GET: api/StudentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDTO>> GetById(int id)
        {
            var studentClass = await _classService.GetById(id);

            if (studentClass == null)
            {
                return NotFound();
            }

            return Ok(studentClass);
        }

        // PUT: api/StudentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ClassDTO>> Put(int id, ClassDTO studentClass)
        {
            if (id != studentClass.ClassId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateClass = await _classService.Put(id, studentClass);
            if (updateClass == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/StudentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassDTO>> Post(ClassDTO studentClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _classService.Post(studentClass);
            return Created("", studentClass);
        }

        // DELETE: api/StudentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _classService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            //return new NoContentWithMessageResult("Student deleted successfully.");
            return NoContent();
        }
    }
}
