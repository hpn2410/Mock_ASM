using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Services
{
    public interface IStudentInfoService
    {
        Task<List<StudentInfoDTO>> GetAllStudentsAsync();
        Task<StudentInfoDTO> GetStudentByIdAsync(int id);
        Task<StudentInfoDTO> CreateStudentAsync(StudentInfoDTO studentInfo);
        Task<StudentInfoDTO> UpdateStudentAsync(int id, StudentInfoDTO studentInfo);
        Task DeleteStudentAsync(int id);
    }
}

