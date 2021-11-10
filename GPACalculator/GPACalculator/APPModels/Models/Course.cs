using APPModels.Models;
using System;

namespace APPModels
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseNameAndCode { get; set; }
        public byte CourseUnit { get; set; }
        public int CourseScore { get; set; }
        public Score ScoreDetails { get; set; }

        public Course(int id, string courseNameAndCode, byte courseUnit, int courseScore, Score scoreDetails)
        {
            Id = id;
            CourseNameAndCode = courseNameAndCode;
            CourseUnit = courseUnit;
            CourseScore = courseScore;
            ScoreDetails = scoreDetails;
        }
        public Course()
        {

        }

    }
}
