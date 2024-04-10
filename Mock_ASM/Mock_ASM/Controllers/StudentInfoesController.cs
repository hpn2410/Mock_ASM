using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;

namespace Mock_ASM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoesController : ControllerBase
    {
        private readonly IStudentInfoService _studentInfoService;

        public StudentInfoesController(IStudentInfoService studentInfoService)
        {
            _studentInfoService = studentInfoService;
        }

        // GET: api/StudentInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInfoDTO>>> GetStudentInfos()
        {
            var students = await _studentInfoService.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/StudentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInfoDTO>> GetStudentInfoById(int id)
        {
            var studentInfo = await _studentInfoService.GetStudentByIdAsync(id);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return Ok(studentInfo);
        }

        // PUT: api/StudentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDTO>> UpdateStudentInfo(int id, StudentInfoDTO studentInfo)
        {
            if (id != studentInfo.StudentInfoId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedStudent = await _studentInfoService.UpdateStudentAsync(id, studentInfo);
            if (updatedStudent == null)
            {
                return NotFound();
            }
            return Ok(updatedStudent);
        }

        // POST: api/StudentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentInfoDTO>> CreateStudentInfo(StudentInfoDTO studentInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = await _studentInfoService.CreateStudentAsync(studentInfo);
            return CreatedAtAction(nameof(GetStudentInfoById), 
                new { id = newStudent.StudentInfoId }, newStudent);
        }

        // DELETE: api/StudentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentInfo(int id)
        {
            var result = await _studentInfoService.DeleteStudentAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
