using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class StudentInfoRepository : IStudentInfoRepository
    {
        private readonly MockAsmContext _DbContext;
        public StudentInfoRepository(MockAsmContext context)
        {
            _DbContext = context;
        }

        public async Task<List<StudentInfo>> GetAllStudentsAsync()
        {
            return await _DbContext.StudentInfos.ToListAsync();
        }

        public async Task<StudentInfo> GetStudentByIdAsync(int id)
        {
            return await _DbContext.StudentInfos.FindAsync(id);
        }

        public async Task<StudentInfo> CreateStudentAsync(StudentInfo studentInfo)
        {
            _DbContext.StudentInfos.Add(studentInfo);
            await _DbContext.SaveChangesAsync();
            return studentInfo;
        }

        public async Task<StudentInfo> UpdateStudentAsync(StudentInfo studentInfo)
        {
            _DbContext.Entry(studentInfo).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
            return studentInfo;
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _DbContext.StudentInfos.FindAsync(id);
            if (student != null)
            {
                _DbContext.StudentInfos.Remove(student);
                await _DbContext.SaveChangesAsync();
            }
        }
    }
}
