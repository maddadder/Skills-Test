using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SkillsTest.Lib
{
    public interface ICourseAPI
    {
        Course GetById(int id);
        Task<IList<Course>> GetByPage<T>(Expression<Func<Course, bool>> predicate, Expression<Func<Course, T>> orderBy, int pageSize=0, int pageNumber=0);
        Task<IList<X_Student_Course>> GetStudentCoursesByPage(string courseName);
    }

    public class DbCourseAPI : ICourseAPI
    {
        public DataContext Db { get; set; }

        public Course GetById(int id)
        {
            return Db.Courses.Where(course => course.Id == id).SingleOrDefault();
        }
        public async Task<IList<Course>> GetByPage<T>(Expression<Func<Course, bool>> predicate, Expression<Func<Course, T>> orderBy, int pageSize=0, int pageNumber=0)
        {
            if(pageNumber == 0)
                pageNumber = 1;
            if(pageSize == 0)
                pageSize = 1;
            pageSize = Math.Abs(pageSize);
            pageNumber = Math.Abs(pageNumber);
            int skip = (pageNumber-1) * pageSize;
            return await Db.Courses.Where(predicate).OrderBy(orderBy).Skip(skip).Take(pageSize).ToListAsync();
        }
        public async Task<IList<X_Student_Course>> GetStudentCoursesByName(string courseName)
        {
            return await (from course in Db.Courses
                    join studentCourses in Db.StudentCourses on course.Id equals studentCourses.CourseId
                    join student in Db.Students on studentCourses.StudentId equals student.Id
                    where course.Name == courseName
                    select studentCourses).ToListAsync();
        }
	}
}