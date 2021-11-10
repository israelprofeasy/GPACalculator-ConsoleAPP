using APPDataAccess.InMemoryRepository.Interface;
using APPDataAccess.InMemoryRepository.Implementation;
using APPLib.Services.Interfaces;
using System;
using APPLib.Services.Implementation;

namespace APPLib
{
    public static class GlobalConfig
    {
        public static IServiceImplementation serviceImplementation;
        public static IResultRepository resultRepository;


        public static void Instantiate()
        {

            resultRepository = new ResultRepositoryImplementation();

            //------------------------------------------------------
            serviceImplementation = new AllServiceImplementation(resultRepository);



        }
    }
}
