using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<StudentInfoDTO>> GetAll()
        {
            //throw new Exception("Test Exception");
            // Add any additional business logic here
            var studentInfoes = await _studentInfoRepository.GetAll();
            return _mapper.Map<List<StudentInfoDTO>>(studentInfoes);
        }

        public async Task<StudentInfoDTO> GetById(int id)
        {
            // Add any additional business logic here
            var studentInfo = await _studentInfoRepository.GetById(id);
            return _mapper.Map<StudentInfoDTO>(studentInfo);
        }

        public async Task<StudentInfoDTO> Post(StudentInfoDTO studentInfo)
        {
            // Add any additional business logic here
            var addStudentInfo = await _studentInfoRepository.Post
                (_mapper.Map<StudentInfoes>(studentInfo));
             return _mapper.Map<StudentInfoDTO>(addStudentInfo);
        }

         public async Task<StudentInfoDTO> Put(int id, StudentInfoDTO studentInfo)
         {
             // Add any additional business logic here
             var updatedStudent = await _studentInfoRepository.
                 Put(_mapper.Map<StudentInfoes>(studentInfo));
             return _mapper.Map<StudentInfoDTO>(updatedStudent);
         }
        

        public async Task<bool> Delete(int id)
        {
            // Add any additional business logic here
            return await _studentInfoRepository.Delete(id);
        }
    }
}
