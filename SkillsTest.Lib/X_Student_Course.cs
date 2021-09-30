using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsTest.Lib
{
    public class X_Student_Course
    {
        [Key, Column(Order = 0)]
        public int CourseId { get; set; }
        [Key, Column(Order = 1)]
        public int StudentId { get; set; }

        public virtual Student Student{get;set;}

        public virtual Course Course{get;set;}
    }
}