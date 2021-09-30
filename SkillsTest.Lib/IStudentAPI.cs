using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkillsTest.Lib
{
    public interface IStudentAPI
    {
        Student GetById(int id);
    }

    public class DbStudentAPI : IStudentAPI
    {
        public DataContext Db { get; set; }

        public Student GetById(int id)
        {
            return Db.Students.Where(student => student.Id == id).SingleOrDefault();
        }
    }
}
