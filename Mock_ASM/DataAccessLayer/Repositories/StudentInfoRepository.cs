using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _DbContext.StudentInfos.FindAsync(id);
            if (student != null)
            {
                _DbContext.StudentInfos.Remove(student);
                await _DbContext.SaveChangesAsync();
            }
            return true;
        }
        public async Task<List<StudentInfo>> GetFilteredAndPagedStudentsAsync(int page, int pageSize, string sortBy, string sortOrder)
        {
            
            int skip = (page - 1) * pageSize;

            
            var query = _DbContext.StudentInfos.AsQueryable();

            
            if (sortOrder.ToLower() == "asc")
            {
                switch (sortBy.ToLower())
                {
                    case "studentinfoid":
                        query = query.OrderBy(s => s.StudentInfoId);
                        break;
                    case "name":
                        query = query.OrderBy(s => s.StudentName);
                        break;
                    
                    default:
                       
                        query = query.OrderBy(s => s.StudentInfoId);
                        break;
                }
            }
            else
            {
                switch (sortBy.ToLower())
                {
                    case "studentinfoid":
                        query = query.OrderByDescending(s => s.StudentInfoId);
                        break;
                    case "name":
                        query = query.OrderByDescending(s => s.StudentName);
                        break;
                    // Thêm các trường sắp xếp khác nếu cần
                    default:
                        // Mặc định sắp xếp theo ID nếu không có trường sắp xếp nào được chỉ định
                        query = query.OrderByDescending(s => s.StudentInfoId);
                        break;
                }
            }

            // Thực hiện phân trang và lấy dữ liệu
            var students = await query.Skip(skip).Take(pageSize).ToListAsync();

            return students;
        }

    }
}
