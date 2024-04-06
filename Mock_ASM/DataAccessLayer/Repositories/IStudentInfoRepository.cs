using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IStudentInfoRepository
    {
        Task<List<StudentInfo>> GetAllStudentsAsync();
        Task<StudentInfo> GetStudentByIdAsync(int id);
        Task CreateStudentAsync(StudentInfo studentInfo);
        Task UpdateStudentAsync(StudentInfo studentInfo);
        Task DeleteStudentAsync(int id);
    }
}
