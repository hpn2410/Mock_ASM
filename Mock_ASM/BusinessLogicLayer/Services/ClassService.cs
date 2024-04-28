using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassService(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassDTO>> GetAll()
        {
            // Add any additional business logic here
            var classes = await _classRepository.GetAll();
            return _mapper.Map<List<ClassDTO>>(classes);
        }

        public async Task<ClassDTO> GetById(int id)
        {
            // Add any additional business logic here
            var studentClass = await _classRepository.GetById(id);
            return _mapper.Map<ClassDTO>(studentClass);
        }

        public async Task<ClassDTO> Post(ClassDTO studentClass)
        {
            // Add any additional business logic here
            var addClass = await _classRepository.Post
                (_mapper.Map<Classes>(studentClass));
            return _mapper.Map<ClassDTO>(addClass);
        }

        public async Task<ClassDTO> Put(int id, ClassDTO studentClass)
        {
            // Add any additional business logic here
            var updateClass = await _classRepository.
                Put(_mapper.Map<Classes>(studentClass));
            return _mapper.Map<ClassDTO>(updateClass);
        }


        public async Task<bool> Delete(int id)
        {
            // Add any additional business logic here
            return await _classRepository.Delete(id);
        }
    }
}
