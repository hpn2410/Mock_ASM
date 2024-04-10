using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.DTO;
using AutoMapper;

namespace BusinessLogicLayer.Services
{
    public class StudentInfoService : IStudentInfoService
    {
        private readonly IStudentInfoRepository _studentInfoRepository;
        private readonly IMapper _mapper;

        public StudentInfoService(IStudentInfoRepository studentInfoRepository, IMapper mapper)
        {
            _studentInfoRepository = studentInfoRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentInfoDTO>> GetAllStudentsAsync()
        {
            // Add any additional business logic here
            var studentInfoes = await _studentInfoRepository.GetAllStudentsAsync();
            return _mapper.Map<List<StudentInfoDTO>>(studentInfoes);
        }

        public async Task<StudentInfoDTO> GetStudentByIdAsync(int id)
        {
            // Add any additional business logic here
            var studentInfo = await _studentInfoRepository.GetStudentByIdAsync(id);
            return _mapper.Map<StudentInfoDTO>(studentInfo);
        }

        public async Task<StudentInfoDTO> CreateStudentAsync(StudentInfoDTO studentInfo)
        {
            // Add any additional business logic here
            var addStudentInfo = await _studentInfoRepository.CreateStudentAsync
                (_mapper.Map<StudentInfo>(studentInfo));
             return _mapper.Map<StudentInfoDTO>(addStudentInfo);
        }

        public async Task<StudentInfoDTO> UpdateStudentAsync(int id, StudentInfoDTO studentInfo)
        {
            // Add any additional business logic here
            var updatedStudent = await _studentInfoRepository.
                UpdateStudentAsync(_mapper.Map<StudentInfo>(studentInfo));
            return _mapper.Map<StudentInfoDTO>(updatedStudent);
        }

        public async Task DeleteStudentAsync(int id)
        {
            // Add any additional business logic here
            await _studentInfoRepository.DeleteStudentAsync(id);
        }
    }
}
