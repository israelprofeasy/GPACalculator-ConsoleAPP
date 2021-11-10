using APPDataAccess.InMemoryRepository.Interface;
using APPLib.Services.DTOs;
using APPLib.Services.Interfaces;
using APPModels;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APPLib.Services.Implementation
{
    public class AllServiceImplementation : IServiceImplementation
    {
        private readonly IResultRepository _resultRepo;
        public AllServiceImplementation(IResultRepository resultRepositoryImplementation)
        {
            _resultRepo = resultRepositoryImplementation;
        }
        //public async Task<List<Course>> GetResult()
        public List<Course> GetResult()
        {

            Console.WriteLine("Calculating GPA...");   // all users will be fetched
            Thread.Sleep(1000);

            //var courses = await _resultRepo.GetResult();
            var courses =  _resultRepo.GetResult();

            return courses;
        }

        //public async Task<bool> Register(CourseDTO model)
        public bool Register(CourseDTO model)
        {
           // var id = 1;

            #region commented
            //var idCard = new IdCard();
            //idCard.UserId =  id;
            //idCard.Title = model.IdCard.Title;
            #endregion

            var course =  new Course(model.Id, model.CourseNameAndCode,model.CourseUnit,model.CourseScore,model.ScoreDetails);
            Console.WriteLine("Adding course...");
            Thread.Sleep(1000);

            if (_resultRepo.Add(course))
                return true;
            

            return false;
        }
    }
}
