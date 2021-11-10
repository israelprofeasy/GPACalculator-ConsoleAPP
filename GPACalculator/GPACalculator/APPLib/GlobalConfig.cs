using APPDataAccess.InMemoryRepository.Interface;
using APPDataAccess.InMemoryRepository.Implementation;
using APPLib.Services.Interfaces;
using System;
using APPLib.Services.Implementation;
using Common;

namespace APPLib
{
    public static class GlobalConfig
    {
        public static IServiceImplementation serviceImplementation;
        public static IResultRepository resultRepository;
        public static Ilogger logger;


        public static void Instantiate()
        {

            resultRepository = new ResultRepositoryImplementation();

            //------------------------------------------------------
            serviceImplementation = new AllServiceImplementation(resultRepository);
            logger = new Logger();



        }
    }
}
