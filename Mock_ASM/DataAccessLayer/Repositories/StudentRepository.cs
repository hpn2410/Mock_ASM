using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MockAsmContext _DbContext;
        public StudentRepository(MockAsmContext context)
        {
            _DbContext = context;
        }

        public async Task<List<Students>> GetAll()
        {
            return await _DbContext.Students.ToListAsync();
        }

        public async Task<Students> GetById(int id)
        {
            return await _DbContext.Students.FindAsync(id);
        }

        public async Task<Students> Post(Students student)
        {
            _DbContext.Students.Add(student);
            await _DbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Students> Put(Students student)
        {
            _DbContext.Entry(student).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
            return student;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _DbContext.Students.FindAsync(id);
            if (student != null)
            {
                _DbContext.Students.Remove(student);
                await _DbContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
