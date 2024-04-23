using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using DataAccessLayer.Sorting;
using DataAccessLayer.Repositories;
using AutoMapper;

namespace Mock_ASM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService,
            IStudentRepository studentRepository, IMapper mapper)
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAll()
        {
            var students = await _studentService.GetAll();
            return Ok(students);
        }

        // GET: api/StudentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetById(int id)
        {
            var student = await _studentService.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/StudentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDTO>> Put(int id, StudentDTO student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedStudent = await _studentService.Put(id, student);
            if (updatedStudent == null)
            {
                return NotFound();
            }
            return Ok(updatedStudent);
        }

        // POST: api/StudentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> Post(StudentDTO student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _studentService.Post(student);
            return student;
        }

        // DELETE: api/StudentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            //return new NoContentWithMessageResult("Student deleted successfully.");
            return NoContent();
        }
        public class NoContentWithMessageResult : StatusCodeResult
        {
            private readonly string _message;

            public NoContentWithMessageResult(string message) : base(204)
            {
                _message = message;
            }

            public override Task ExecuteResultAsync(ActionContext context)
            {
                return base.ExecuteResultAsync(context);
            }
        }
    }
}
