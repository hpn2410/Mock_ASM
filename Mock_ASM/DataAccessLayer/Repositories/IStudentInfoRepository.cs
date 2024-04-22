using DataAccessLayer.Models;
using DataAccessLayer.Sorting;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface IStudentInfoRepository
    {
        Task<List<StudentInfo>> GetAllStudentsAsync();
        Task<StudentInfo> GetStudentByIdAsync(int id);
        Task<StudentInfo> CreateStudentAsync(StudentInfo studentInfo);
        Task<StudentInfo> UpdateStudentAsync(StudentInfo studentInfo);
        Task<bool> DeleteStudentAsync(int id);
        IEnumerable<StudentInfo> GetStudentInfoes(string? studentName,string? email, 
            SortField? sortField, SortType? sortType, 
            int pageNumber, int pageSize, out int totalRecords);
    }
}
