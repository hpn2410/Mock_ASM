using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentDTO>> GetAll()
        {
            // Add any additional business logic here
            var students = await _studentRepository.GetAll();
            return _mapper.Map<List<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetById(int id)
        {
            // Add any additional business logic here
            var student = await _studentRepository.GetById(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> Post(StudentDTO student)
        {
            // Add any additional business logic here
            var addStudent = await _studentRepository.Post
                (_mapper.Map<Student>(student));
            return _mapper.Map<StudentDTO>(addStudent);
        }

        public async Task<StudentDTO> Put(int id, StudentDTO student)
        {
            // Add any additional business logic here
            var updatedStudent = await _studentRepository.
                Put(_mapper.Map<Student>(student));
            return _mapper.Map<StudentDTO>(updatedStudent);
        }


        public async Task<bool> Delete(int id)
        {
            // Add any additional business logic here
            return await _studentRepository.Delete(id);
        }
    }
}
