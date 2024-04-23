using DataAccessLayer.Models;
using DataAccessLayer.Sorting;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface IStudentInfoRepository
    {
        Task<List<StudentInfo>> GetAll();
        Task<StudentInfo> GetById(int id);
        Task<StudentInfo> Post(StudentInfo studentInfo);
        Task<StudentInfo> Put(StudentInfo studentInfo);
        Task<bool> Delete(int id);
        IEnumerable<StudentInfo> GetStudentInfoes(string? studentName,string? email, 
            SortField? sortField, SortType? sortType, 
            int pageNumber, int pageSize, out int totalRecords);
    }
}
