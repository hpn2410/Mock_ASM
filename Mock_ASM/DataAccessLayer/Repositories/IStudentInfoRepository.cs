using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IStudentInfoRepository
    {
        Task<List<StudentInfo>> GetAllStudentsAsync();
        Task<StudentInfo> GetStudentByIdAsync(int id);
        Task<StudentInfo> CreateStudentAsync(StudentInfo studentInfo);
        Task<StudentInfo> UpdateStudentAsync(StudentInfo studentInfo);
        Task<bool> DeleteStudentAsync(int id);
        Task<List<StudentInfo>> GetFilteredAndPagedStudentsAsync(int page, int pageSize, string sortBy, string sortOrder);
    }
}
