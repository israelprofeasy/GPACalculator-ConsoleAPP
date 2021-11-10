using APPModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APPDataAccess.FileMemory
{
    public static class FileMemory
    {
        public static string filePath = @"C:\Users\hp\Desktop\week-4-israelprofeasy\GPACalculator\GPACalculator\Data\courses.txt";

        public static bool Write(Course course)
        {
            string textOutput = $"{course.CourseNameAndCode}, {course.CourseUnit}, {course.CourseScore}, {course.ScoreDetails.Grade}, {course.ScoreDetails.Point}, {course.ScoreDetails.Remarks}";
            string newOutput = string.Join(",", textOutput);

            try
            {
                if (File.Exists(filePath)) File.AppendAllText(filePath, newOutput + "\n");
                else File.WriteAllText(filePath, newOutput + "\n");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        //public static async Task<List<Course>> ReadAsync()
        public static async Task<List<Course>> ReadAsync()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var lines = (await File.ReadAllLinesAsync(filePath)).ToList();
                    List<Course> courses = new List<Course>();
                    foreach(var text in lines)
                    {
                        List<string> input = text.Split(',').ToList();
                        Course course = new Course();
                        course.CourseNameAndCode = input[0];
                        course.CourseUnit = Convert.ToByte(input[1]);
                        course.CourseScore = Convert.ToInt32(input[2]);
                         course.ScoreDetails.Grade = input[3];
                        course.ScoreDetails.Point = Convert.ToByte(input[4]);
                        course.ScoreDetails.Remarks = input[5];
                        courses.Add(course);


                    }
                    return courses;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public static void Delete()
        {
            File.Delete(filePath);
        }
      /*  public static  bool Add<T>(T entity)
        {
            int rowCountBefore = this.RowCount();
            var course = entity as Course; // convert generic type value to concrete type user
            Result.Courses.Add(course);

            FileMemory.Write(course);

            int rowCountAfter = this.RowCount();

            if (rowCountAfter <= rowCountBefore)
                return false;

            return true;
        }*/
    }
}
