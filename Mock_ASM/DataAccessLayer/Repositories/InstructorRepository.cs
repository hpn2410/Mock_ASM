using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface InstructorRepository
    {
        Task<List<Instructor>> GetAll();
        Task<Instructor> GetById(int id);
        Task<Instructor> Post(Instructor instructor);
        Task<Instructor> Put(Instructor instructor);
        Task<bool> Delete(int id);
    }
}
