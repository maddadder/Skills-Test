using Microsoft.EntityFrameworkCore;
using SkillsTest.Lib;
using System.Collections.Generic;
using System.Linq;

namespace SkillsTest.Tests
{
    internal class DataContextHelper
    {
        /// <summary>
        /// Returns an instance of the In-Memory db context for testing
        /// </summary>
        /// <returns></returns>
        public static DataContext GetMockDb(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(name)
                .Options;

            var db = new DataContext(options);

            // Seed the database

            if (!db.Courses.Any())
            {
                db.Courses.AddRange(new[]
                {
                    new Course { Id = 1, Name = "Advanced Basketweaving" },
                    new Course { Id = 2, Name = "Math for Liberal Arts Majors" },
                    new Course { Id = 3, Name = "The Cosmos: An Introduction" }
                });

                db.SaveChanges();
            }

            if (!db.Students.Any())
            {
                foreach (var iteration in Enumerable.Range(1, 100))
                {
                    var student = new Student
                    {
                        Id = iteration,
                        FirstName = "Test",
                        LastName = $"Student {iteration}",
                    };
                    var StudentCourses = new List<X_Student_Course>();
                    foreach(var course in db.Courses.Where(course => iteration % course.Id == 0).ToList())
                    {
                        X_Student_Course studentCourse = new X_Student_Course();
                        studentCourse.CourseId = course.Id;
                        studentCourse.Course = course;
                        studentCourse.StudentId = iteration;
                        StudentCourses.Add(studentCourse);
                    }
                    student.StudentCourses = StudentCourses;
                    db.Students.Add(student);
                }

                db.SaveChanges();
            }

            return db;
        }
    }
}