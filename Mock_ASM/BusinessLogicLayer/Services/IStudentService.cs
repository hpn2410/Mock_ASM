using DataAccessLayer.Models;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Services
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAll();
        Task<StudentDTO> GetById(int id);
        Task<StudentDTO> Post(StudentDTO student);
        Task<StudentDTO> Put(int id, StudentDTO student);
        Task<bool> Delete(int id);
    }
}
