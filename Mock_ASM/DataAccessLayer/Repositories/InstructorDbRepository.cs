using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class InstructorDbRepository : InstructorRepository
    {
        private readonly MockAsmContext _DbContext;
        public InstructorDbRepository(MockAsmContext context)
        {
            _DbContext = context;
        }

        public async Task<List<Instructors>> GetAll()
        {
            return await _DbContext.Instructors.ToListAsync();
        }

        public async Task<Instructors> GetById(int id)
        {
            return await _DbContext.Instructors.FindAsync(id);
        }

        public async Task<Instructors> Post(Instructors instructor)
        {
            _DbContext.Instructors.Add(instructor);
            await _DbContext.SaveChangesAsync();
            return instructor;
        }

        public async Task<Instructors> Put(Instructors instructor)
        {
            _DbContext.Entry(instructor).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
            return instructor;
        }

        public async Task<bool> Delete(int id)
        {
            var instructor = await _DbContext.Instructors.FindAsync(id);
            if (instructor != null)
            {
                _DbContext.Instructors.Remove(instructor);
                await _DbContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
