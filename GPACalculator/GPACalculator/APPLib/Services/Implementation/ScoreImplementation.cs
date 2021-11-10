using APPLib.Services.DTOs;
using APPLib.Services.Interfaces;
using APPModels;
using APPModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPLib.Services.Implementation
{
    public static class ScoreImplementation 
    {

       
        public static float GradePointAverage(List<Course> courses)
        {
            float GPA = 0.00f;
            if (courses.Count > 0)
            {
                int totalQualityPoint = 0;
                int totalGradeUnit = 0;

                for (int i = 0; i < courses.Count; i++)
                {
                    totalQualityPoint += (courses[i].CourseUnit * courses[i].ScoreDetails.Point);
                    totalGradeUnit += courses[i].ScoreDetails.Point;

                }
                var answer = (float) totalQualityPoint / totalGradeUnit;
                GPA = (float)Math.Round(answer, 2);
            }
            return GPA;
        }

       public static Score ScoreDetails(int score)
        {
            var scoreDetails = new Score();
            switch (score)
            {
                case int n when (n >= 70 && n <= 100):
                    scoreDetails.Grade = 'A';
                    scoreDetails.Remarks = "Excellent";
                    scoreDetails.Point = 5;
                    break;

                case int n when (n >= 60 && n <= 69):
                    scoreDetails.Grade = 'B';
                    scoreDetails.Remarks = "Very Good";
                    scoreDetails.Point  = 4;
                    break;

                case int n when (n >= 50 && n <= 59):
                    scoreDetails.Grade = 'C';
                    scoreDetails.Remarks = "Good";
                    scoreDetails.Point = 3;
                    break;

                case int n when (n >= 45 && n <= 49):
                    scoreDetails.Grade = 'D';
                    scoreDetails.Remarks = "Fair";
                    scoreDetails.Point = 2;
                    break;
                case int n when (n >= 40 && n <= 44):
                    scoreDetails.Grade = 'E';
                    scoreDetails.Remarks = "Poor";
                    scoreDetails.Point  = 1;
                    break;
                default:
                    scoreDetails.Grade = 'F';
                    scoreDetails.Remarks = "Fail";
                    scoreDetails.Point  = 0;
                    break;

            }
            return scoreDetails;
        }
    }
}
