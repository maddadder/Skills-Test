using System.Linq;

namespace SkillsTest.Lib
{
    public interface ICourseAPI
    {
        Course GetById(int id);
    }

    public class DbCourseAPI : ICourseAPI
    {
        public DataContext Db { get; set; }

        public Course GetById(int id)
        {
            return Db.Courses.Where(course => course.Id == id).SingleOrDefault();
        }
    }
}