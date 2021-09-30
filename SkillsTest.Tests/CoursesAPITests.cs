using SkillsTest.Lib;
using Xunit;

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
    }
}