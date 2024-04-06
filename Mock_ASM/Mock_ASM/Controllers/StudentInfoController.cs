using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace Mock_ASM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController : ControllerBase
    {
        private readonly MockAsmContext _context;

        public StudentInfoController(MockAsmContext context)
        {
            _context = context;
        }

        // GET: api/StudentInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInfo>>> GetStudentInfos()
        {
            return await _context.StudentInfos.ToListAsync();
        }

        // GET: api/StudentInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInfo>> GetStudentInfo(int id)
        {
            var studentInfo = await _context.StudentInfos.FindAsync(id);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return studentInfo;
        }

        // PUT: api/StudentInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentInfo(int id, StudentInfo studentInfo)
        {
            if (id != studentInfo.StudentInfoId)
            {
                return BadRequest();
            }

            _context.Entry(studentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentInfo>> PostStudentInfo(StudentInfo studentInfo)
        {
            _context.StudentInfos.Add(studentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentInfo", new { id = studentInfo.StudentInfoId }, studentInfo);
        }

        // DELETE: api/StudentInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentInfo(int id)
        {
            var studentInfo = await _context.StudentInfos.FindAsync(id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            _context.StudentInfos.Remove(studentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentInfoExists(int id)
        {
            return _context.StudentInfos.Any(e => e.StudentInfoId == id);
        }
    }
}
