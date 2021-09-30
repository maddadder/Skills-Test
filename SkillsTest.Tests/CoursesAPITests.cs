using System.Collections.Generic;
using SkillsTest.Lib;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SkillsTest.Tests
{
    public class CoursesAPITests
    {
        private DbCourseAPI api = new DbCourseAPI
        {
            Db = DataContextHelper.GetMockDb(nameof(CoursesAPITests))
        };

        [Fact]
        public void Can_Get_Course_With_Id_1()
        {
            var course = api.GetById(1);

            Assert.NotNull(course);
        }
        [Fact]
        public async Task get_all_students_ordered_by_last_name_as_pageable()
        {
            List<Course> results = new List<Course>();
            IList<Course> queryResults = new List<Course>(){new Course()};
            int pageNumber = 1;
            int pageSize = 1;
            int resultCount = 0;
            while(queryResults.Count > 0)
            {
                queryResults = await api.GetByPage(x => x.Id > 0, x => x.Name, pageSize, pageNumber);
                Assert.NotNull(queryResults);
                results.AddRange(queryResults);
                if(queryResults.Count > 0)
                    resultCount += pageSize;
                pageNumber += 1;
            }
            Assert.Equal(results.Count,resultCount);
        }
        [Fact]
        public async Task Find_all_students_enrolled_in_specified_course(){

            var queryResults = await api.GetStudentCoursesByPage("The Cosmos: An Introduction");
            foreach(var row in queryResults)
            {
                Console.WriteLine(row.Student.LastName);
            }
        }
    }
}