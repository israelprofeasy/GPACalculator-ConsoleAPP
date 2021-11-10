using APPLib;
using System;

namespace APPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfig.Instantiate();

            var acc = new UserImplementation(GlobalConfig.serviceImplementation);



            // Test to register new user
            acc.AddCourse();

            Console.WriteLine("\n\n");
            

            // Test to view new user details
            acc.DisplayResult();

        }
    }
}
