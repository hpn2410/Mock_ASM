using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface InstructorRepository
    {
        Task<List<Instructors>> GetAll();
        Task<Instructors> GetById(int id);
        Task<Instructors> Post(Instructors instructor);
        Task<Instructors> Put(Instructors instructor);
        Task<bool> Delete(int id);
    }
}
