using APPDataAccess.InMemoryRepository.Interface;
using APPModels;
using APPDataAccess.FileMemory;
using APPModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APPDataAccess.InMemoryRepository.Implementation
{
    public class ResultRepositoryImplementation : IResultRepository
    {
        public ResultRepositoryImplementation()
        {
        }

        public bool Add<T>(T entity)
        {
            int rowCountBefore = this.RowCount();
            var course = entity as Course; // convert generic type value to concrete type user
            Result.Courses.Add(course);
            FileMemory.FileMemory.Write(course);

           

            int rowCountAfter = this.RowCount();

            if (rowCountAfter <= rowCountBefore)
                return false;

            return true;
        }

        public string Delete<T>(T entity)
        {
            int rowCountBefore = this.RowCount();

            if (rowCountBefore < 1)
                return "No record found! Table is empty";

            var course = entity as Course; // convert generic type value to concrete type user
            Result.Courses.Remove(course);
            int rowCountAfter = this.RowCount();

            if (rowCountAfter >= rowCountBefore)
                return "false";

            return "true";
        }

        public int RowCount()
        {
            return Result.Courses.Count;
        }

        public Course SelectCourse(int Id)
        {
            int count = Result.Courses.Count;
            for (int i = 0; i < Result.Courses.Count; i++)
            {
                if (Result.Courses[i].Id.Equals(Id))
                {
                    return Result.Courses[i];
                }

                if (Result.Courses[count].Id.Equals(Id))
                {
                    return Result.Courses[count];
                }
                count--;
            }

            return null;
        }

        //public async Task<List<Course>> GetResult()
        public List<Course> GetResult()
        {
            int rowCountBefore = this.RowCount();

            if (rowCountBefore < 1)
                return null;

            //return await Task.FromResult(Result.Courses);
            //return Result.Courses;
            return FileMemory.FileMemory.ReadAsync().Result;

        }

        public string Update<T>(T entity)
        {
            int rowCountBefore = this.RowCount();

            if (rowCountBefore < 1)
                return "No record found! Table is empty";

            var course = entity as Course; // convert generic type value to concrete type user

            int count = Result.Courses.Count;
            for (int i = 0; i < Result.Courses.Count; i++)
            {
                if (Result.Courses[i].Equals(course))
                {
                    Result.Courses[i].CourseNameAndCode = course.CourseNameAndCode;
                    Result.Courses[i].CourseUnit = course.CourseUnit;
                    Result.Courses[i].CourseScore = course.CourseScore;
                    Result.Courses[i].ScoreDetails= course.ScoreDetails;
                    return "true";
                }

                if (Result.Courses[count].Equals(course))
                {
                    Result.Courses[count].CourseNameAndCode = course.CourseNameAndCode;
                    Result.Courses[count].CourseUnit = course.CourseUnit;
                    Result.Courses[count].CourseScore = course.CourseScore;
                    Result.Courses[i].ScoreDetails = course.ScoreDetails;
                    return "true";
                }
                count--;
            }

            return "false";
        }

        //Task<List<Course>> ICRUDRepository.Get()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

