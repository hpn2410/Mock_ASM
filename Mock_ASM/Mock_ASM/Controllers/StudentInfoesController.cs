
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
    public class StudentInfoesController : ControllerBase
    {
        private readonly IStudentInfoService _studentInfoService;
        private readonly IStudentInfoRepository _studentInfoRepository;
        private readonly IMapper _mapper;

        public StudentInfoesController(IStudentInfoService studentInfoService, 
            IStudentInfoRepository studentInfoRepository, IMapper mapper)
        {
            _studentInfoService = studentInfoService;
            _studentInfoRepository = studentInfoRepository;
            _mapper = mapper;
        }

        // GET: api/StudentInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInfoDTO>>> GetAll()
        {
            var students = await _studentInfoService.GetAll();
            return Ok(students);
        }

        // GET: api/StudentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInfoDTO>> GetById(int id)
        {
            var studentInfo = await _studentInfoService.GetById(id);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return Ok(studentInfo);
        }

        // PUT: api/StudentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentInfoDTO>> Put(int id, 
            StudentInfoDTO studentInfo)
        {
            if (id != studentInfo.StudentInfoId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedStudent = await _studentInfoService.Put(id, studentInfo);
            if (updatedStudent == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/StudentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentInfoDTO>> Post(StudentInfoDTO studentInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _studentInfoService.Post(studentInfo);
            //return CreatedAtAction(nameof(GetStudentInfoById), 
            //    new { id = newStudent.StudentInfoId }, newStudent);
            return studentInfo;
        }

        // DELETE: api/StudentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentInfoService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return new NoContentWithMessageResult("Student deleted successfully.");
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

        [HttpGet("filter")]
        public ActionResult<IEnumerable<StudentInfoDTO>> GetStudents([FromQuery] string? studentName,
            [FromQuery] string? email, [FromQuery] SortField? sortField, 
            [FromQuery] SortType? sortType, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            int totalRecords;
            var studentInfos = _studentInfoRepository.GetStudentInfoes(
                studentName, email, sortField, sortType, pageNumber,
                pageSize, out totalRecords);
            var studentInfoDTOs = _mapper.Map<IEnumerable<StudentInfoDTO>>(studentInfos);

            Response.Headers.Add("X-Total-Count", totalRecords.ToString());
            return Ok(studentInfoDTOs);
        }
    }
}
