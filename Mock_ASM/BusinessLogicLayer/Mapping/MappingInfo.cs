using DataAccessLayer.Models;
using AutoMapper;
using BusinessLogicLayer.DTO;
using System.Diagnostics;
namespace BusinessLogicLayer.Mapping
{
    public class MappingInfo : Profile
    {
        public MappingInfo()
        {
            // StudentInfo CreateMap
            CreateMap<StudentInfo, StudentInfoDTO>().ReverseMap();
            CreateMap<StudentInfoDTO, StudentInfo>().ReverseMap();

            // Student CreateMap
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<StudentDTO, Student>().ReverseMap();

            // Instructor CreateMap
            CreateMap<Instructor, InstructorDTO>().ReverseMap();
            CreateMap<InstructorDTO, Instructor>().ReverseMap();

            // Class CreateMap
            CreateMap<Class, ClassDTO>().ReverseMap();
            CreateMap<ClassDTO, Class>().ReverseMap();
        }
    }
    
}
