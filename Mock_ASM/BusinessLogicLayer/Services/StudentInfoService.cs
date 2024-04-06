using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
    public class StudentInfoService : IStudentInfoService
    {
        private readonly IStudentInfoRepository _studentInfoRepository;

        public StudentInfoService(IStudentInfoRepository studentInfoRepository)
        {
            _studentInfoRepository = studentInfoRepository;
        }

        public async Task<List<StudentInfo>> GetAllStudentsAsync()
        {
            // Add any additional business logic here
            return await _studentInfoRepository.GetAllStudentsAsync();
        }

        public async Task<StudentInfo> GetStudentByIdAsync(int id)
        {
            // Add any additional business logic here
            return await _studentInfoRepository.GetStudentByIdAsync(id);
        }

        public async Task CreateStudentAsync(StudentInfo studentInfo)
        {
            // Add any additional business logic here
            await _studentInfoRepository.CreateStudentAsync(studentInfo);
        }

        public async Task UpdateStudentAsync(StudentInfo studentInfo)
        {
            // Add any additional business logic here
            await _studentInfoRepository.UpdateStudentAsync(studentInfo);
        }

        public async Task DeleteStudentAsync(int id)
        {
            // Add any additional business logic here
            await _studentInfoRepository.DeleteStudentAsync(id);
        }
    }
}
