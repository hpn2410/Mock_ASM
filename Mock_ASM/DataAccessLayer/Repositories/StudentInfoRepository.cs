using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using SortField = DataAccessLayer.Sorting.SortField;
using SortType = DataAccessLayer.Sorting.SortType;

namespace DataAccessLayer.Repositories
{
    public class StudentInfoRepository : IStudentInfoRepository
    {
        private readonly MockAsmContext _DbContext;
        public StudentInfoRepository(MockAsmContext context)
        {
            _DbContext = context;
        }

        public async Task<List<StudentInfoes>> GetAll()
        {
            return await _DbContext.StudentInfos.ToListAsync();
        }

        public async Task<StudentInfoes> GetById(int id)
        {
            return await _DbContext.StudentInfos.FindAsync(id);
        }

        public async Task<StudentInfoes> Post(StudentInfoes studentInfo)
        {
            _DbContext.StudentInfos.Add(studentInfo);
            await _DbContext.SaveChangesAsync();
            return studentInfo;
        }

        public async Task<StudentInfoes> Put(StudentInfoes studentInfo)
        {
            _DbContext.Entry(studentInfo).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
            return studentInfo;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _DbContext.StudentInfos.FindAsync(id);
            if (student != null)
            {
                _DbContext.StudentInfos.Remove(student);
                await _DbContext.SaveChangesAsync();
            }
            return true;
        }

        public IEnumerable<StudentInfoes> GetStudentInfoes(string? studentName, string? email,
            SortField? sortField, SortType? sortType,
            int pageNumber, int pageSize, out int totalRecords)
        {
            var query = _DbContext.StudentInfos.AsQueryable();

            // Apply filtering
            if (!string.IsNullOrWhiteSpace(studentName))
            {
                query = query.Where(s => s.StudentName != null && s.StudentName.Contains(studentName));
            }
            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(s => s.Email != null && s.Email.Contains(email));
            }

            // Apply sorting
            if (sortField.HasValue && sortType.HasValue)
            {
                switch (sortField.Value)
                {
                    case SortField.StudentName:
                        query = sortType == SortType.Ascending ?
                            query.OrderBy(s => s.StudentName) :
                            query.OrderByDescending(s => s.StudentName);
                        break;
                    case SortField.DateOfBirth:
                        query = sortType == SortType.Ascending ?
                            query.OrderBy(s => s.DateOfBirth) :
                            query.OrderByDescending(s => s.DateOfBirth);
                        break;
                    case SortField.Phone:
                        query = sortType == SortType.Ascending ?
                            query.OrderBy(s => s.Phone) :
                            query.OrderByDescending(s => s.Phone);
                        break;
                    case SortField.Email:
                        query = sortType == SortType.Ascending ?
                            query.OrderBy(s => s.Email) :
                            query.OrderByDescending(s => s.Email);
                        break;
                }
            }

            totalRecords = query.Count();


            // Apply pagination
            var paginatedQuery = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return paginatedQuery.ToList();
        }
    }
}
