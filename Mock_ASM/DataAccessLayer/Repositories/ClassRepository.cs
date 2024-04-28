using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly MockAsmContext _DbContext;
        public ClassRepository(MockAsmContext context)
        {
            _DbContext = context;
        }

        public async Task<List<Classes>> GetAll()
        {
            return await _DbContext.Classes.ToListAsync();
        }

        public async Task<Classes> GetById(int id)
        {
            return await _DbContext.Classes.FindAsync(id);
        }

        public async Task<Classes> Post(Classes studentClass)
        {
            _DbContext.Classes.Add(studentClass);
            await _DbContext.SaveChangesAsync();
            return studentClass;
        }

        public async Task<Classes> Put(Classes studentClass)
        {
            _DbContext.Entry(studentClass).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
            return studentClass;
        }

        public async Task<bool> Delete(int id)
        {
            var studentClass = await _DbContext.Classes.FindAsync(id);
            if (studentClass != null)
            {
                _DbContext.Classes.Remove(studentClass);
                await _DbContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
