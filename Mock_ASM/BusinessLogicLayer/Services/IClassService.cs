using DataAccessLayer.Models;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Services
{
    public interface IClassService
    {
        Task<List<ClassDTO>> GetAll();
        Task<ClassDTO> GetById(int id);
        Task<ClassDTO> Post(ClassDTO studentClass);
        Task<ClassDTO> Put(int id, ClassDTO studentClass);
        Task<bool> Delete(int id);
    }
}
