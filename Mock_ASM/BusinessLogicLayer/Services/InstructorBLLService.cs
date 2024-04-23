

using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
    public class InstructorBLLService : InstructorService
    {
        private readonly InstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public InstructorBLLService(InstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<List<InstructorDTO>> GetAll()
        {
            // Add any additional business logic here
            var instructors = await _instructorRepository.GetAll();
            return _mapper.Map<List<InstructorDTO>>(instructors);
        }

        public async Task<InstructorDTO> GetById(int id)
        {
            // Add any additional business logic here
            var instructor = await _instructorRepository.GetById(id);
            return _mapper.Map<InstructorDTO>(instructor);
        }

        public async Task<InstructorDTO> Post(InstructorDTO instructor)
        {
            // Add any additional business logic here
            var addInstructor = await _instructorRepository.Post
                (_mapper.Map<Instructor>(instructor));
            return _mapper.Map<InstructorDTO>(addInstructor);
        }

        public async Task<InstructorDTO> Put(int id, InstructorDTO instructor)
        {
            // Add any additional business logic here
            var updatedInstructor = await _instructorRepository.
                Put(_mapper.Map<Instructor>(instructor));
            return _mapper.Map<InstructorDTO>(updatedInstructor);
        }


        public async Task<bool> Delete(int id)
        {
            // Add any additional business logic here
            return await _instructorRepository.Delete(id);
        }
    }
}
