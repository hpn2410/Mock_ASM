using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mock_ASM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly InstructorService _instructorService;
        private readonly InstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public InstructorsController(InstructorService instructorService,
            InstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorService = instructorService;
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorDTO>>> GetAll()
        {
            var instructors = await _instructorService.GetAll();
            return Ok(instructors);
        }

        // GET: api/StudentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDTO>> GetById(int id)
        {
            var instructor = await _instructorService.GetById(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(instructor);
        }

        // PUT: api/StudentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<InstructorDTO>> Put(int id, InstructorDTO instructor)
        {
            if (id != instructor.InstructorId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateInstructor = await _instructorService.Put(id, instructor);
            if (updateInstructor == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/StudentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InstructorDTO>> Post(InstructorDTO instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _instructorService.Post(instructor);
            return CreatedAtRoute(new {}, instructor);
        }

        // DELETE: api/StudentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _instructorService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            //return new NoContentWithMessageResult("Student deleted successfully.");
            return NoContent();
        }
    }
}
