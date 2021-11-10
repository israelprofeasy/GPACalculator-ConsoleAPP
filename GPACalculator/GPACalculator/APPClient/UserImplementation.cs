using APPLib.Services.Implementation;
using APPLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using APPModels;
using APPLib.Services.DTOs;
using System.Threading.Tasks;
using Common;

namespace APPClient
{
    class UserImplementation
    {
        private readonly IServiceImplementation _courseRepo;
        private readonly Ilogger _logger;
        public UserImplementation(IServiceImplementation courseRepo, Ilogger logger)
        {
            _courseRepo = courseRepo;
            _logger = logger;
        }

       
        public void AddCourse()
        {
            Console.WriteLine("********************************************************************************************************************");
            Console.WriteLine("**************************************************Grade Point Average Calculator (GPA)********************************");

            bool courseCount = true;


            while (courseCount==true)
            {
                int id = 1;
                Console.Write("Enter Course Name (Example: AAA): ");
                string courseName = Console.ReadLine();

                Console.Write("Enter Course Code (Example: 222): ");
                string courseCode = Console.ReadLine();
                Console.Write("Enter Course unit: ");
                byte courseUnit = byte.Parse(Console.ReadLine());
                Console.Write("Enter Course Score: ");
                int courseScore = int.Parse(Console.ReadLine());
                string course = courseName + " " + courseCode;
                //Course courses = new Course(course, courseUnit, courseScore);
               // var coursees = new Course(id, course, courseUnit, courseScore, ScoreImplementation.ScoreDetails(courseScore));
                var result = _courseRepo.Register(new CourseDTO { Id = id, CourseNameAndCode = course, CourseUnit = courseUnit, CourseScore = courseScore, 
                                                                    ScoreDetails = ScoreImplementation.ScoreDetails(courseScore) });
                


                if (result)
                {
                    id++;
                    
                    Console.WriteLine("Added new course successfully!");
                    Console.Write("Do you want to add another course? Y/N : ");
                    string choice = Console.ReadLine();
                    if(choice=="Y" ||choice=="y" || choice=="yes" || choice == "Yes")
                    {
                        courseCount = true;
                    }
                    else
                    {
                        courseCount = false;
                    }
                }
                else
                    Console.WriteLine("Operation to add new user failed!");

                


            }

        }
        //public async Task  DisplayResult()
        public void  DisplayResult()
        {
            //var courses = await _courseRepo.GetResult();
            var courses =  _courseRepo.GetResult();
            if (courses.Equals(null))
                Console.WriteLine("No course Added for computation!");
            else
            {
                Console.WriteLine("|-----------------------|----------------|---------|------------|");
                Console.WriteLine("|      COURSE & CODE    |   COURSE UNIT  |  GRADE  | GRADE UNIT |");
                Console.WriteLine("|-----------------------|----------------|---------|------------|");
                foreach(var course in courses)
                {
                    Console.WriteLine($"| {course.CourseNameAndCode}\t\t| {course.CourseUnit} \t\t | {course.ScoreDetails.Grade} \t   | {course.ScoreDetails.Point} \t\t|");

                }
                Console.WriteLine("|-----------------------|----------------|---------|------------|");
                Console.WriteLine($"Your GPA is = {ScoreImplementation.GradePointAverage(courses)} to 2 decimal places.");
            }
        }


    }
}
