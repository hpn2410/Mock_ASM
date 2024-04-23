using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Services
{
    public interface InstructorService
    {
        Task<List<InstructorDTO>> GetAll();
        Task<InstructorDTO> GetById(int id);
        Task<InstructorDTO> Post(InstructorDTO instructor);
        Task<InstructorDTO> Put(int id, InstructorDTO instructor);
        Task<bool> Delete(int id);
    }
}
