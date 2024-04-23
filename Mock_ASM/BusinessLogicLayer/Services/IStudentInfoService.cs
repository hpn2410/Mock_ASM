
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Services
{
    public interface IStudentInfoService
    {
        Task<List<StudentInfoDTO>> GetAll();
        Task<StudentInfoDTO> GetById(int id);
        Task<StudentInfoDTO> Post(StudentInfoDTO studentInfo);
        Task<StudentInfoDTO> Put(int id, StudentInfoDTO studentInfo);
        Task<bool> Delete(int id);
    }
}

