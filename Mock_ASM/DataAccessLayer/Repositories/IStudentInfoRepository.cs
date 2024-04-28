using DataAccessLayer.Models;
using DataAccessLayer.Sorting;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface IStudentInfoRepository
    {
        Task<List<StudentInfoes>> GetAll();
        Task<StudentInfoes> GetById(int id);
        Task<StudentInfoes> Post(StudentInfoes studentInfo);
        Task<StudentInfoes> Put(StudentInfoes studentInfo);
        Task<bool> Delete(int id);
        IEnumerable<StudentInfoes> GetStudentInfoes(string? studentName,string? email, 
            SortField? sortField, SortType? sortType, 
            int pageNumber, int pageSize, out int totalRecords);
    }
}
