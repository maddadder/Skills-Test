using SkillsTest.Lib;
using Xunit;

namespace SkillsTest.Tests
{
    public class StudentAPITests
    {
        private DbStudentAPI api = new DbStudentAPI
        {
            Db = DataContextHelper.GetMockDb(nameof(StudentAPITests))
        };

        [Fact]
        public void Can_Get_Student_With_Id_1()
        {
            var student = api.GetById(1);

            Assert.NotNull(student);
        }
    }
}