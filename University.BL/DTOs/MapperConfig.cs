using University.BL.Models;
using AutoMapper;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(x => {

                x.CreateMap<Course, CourseDTO>().ReverseMap();
                x.CreateMap<Student, StudentDTO>().ReverseMap();
                x.CreateMap<Instructor, InstructorDTO>().ReverseMap();
                x.CreateMap<Student, StudentDTO>().ReverseMap();
                x.CreateMap<OfficeAssignment, OfficeAssignmentDTO>().ReverseMap();

            });
        }
    }
}
