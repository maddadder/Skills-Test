using System;
using System.Collections.Generic;

namespace SkillsTest.Lib
{
    public class Course
    {
        public int Id { get; set; }
        
        public String Name { get; set; }

        public virtual ICollection<X_Student_Course> StudentCourses { get; set; }
    }
}