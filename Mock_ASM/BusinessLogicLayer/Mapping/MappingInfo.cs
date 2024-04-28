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
            CreateMap<StudentInfoes, StudentInfoDTO>().ReverseMap();
            CreateMap<StudentInfoDTO, StudentInfoes>().ReverseMap();

            // Student CreateMap
            CreateMap<Students, StudentDTO>().ReverseMap();
            CreateMap<StudentDTO, Students>().ReverseMap();

            // Instructor CreateMap
            CreateMap<Instructors, InstructorDTO>().ReverseMap();
            CreateMap<InstructorDTO, Instructors>().ReverseMap();

            // Class CreateMap
            CreateMap<Classes, ClassDTO>().ReverseMap();
            CreateMap<ClassDTO, Classes>().ReverseMap();
        }
    }
    
}
