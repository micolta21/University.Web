using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(UniversityModel universityContext) : base(universityContext)
        {

        }
    }
}
