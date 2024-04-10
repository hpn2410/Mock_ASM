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
            CreateMap<StudentInfo, StudentInfoDTO>();

            CreateMap<Class, ClassDTO>().ReverseMap();
            CreateMap<Instructor, InstructorDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
    
}
