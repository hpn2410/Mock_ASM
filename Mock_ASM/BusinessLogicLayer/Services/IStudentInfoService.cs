using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    public interface IStudentInfoService
    {
        Task<List<StudentInfo>> GetAllStudentsAsync(); // Update return type
        Task<StudentInfo> GetStudentByIdAsync(int id); // Update return type
        Task CreateStudentAsync(StudentInfo studentInfo); // Update parameter type
        Task UpdateStudentAsync(StudentInfo studentInfo); // Update parameter type
        Task DeleteStudentAsync(int id);
    }
}
