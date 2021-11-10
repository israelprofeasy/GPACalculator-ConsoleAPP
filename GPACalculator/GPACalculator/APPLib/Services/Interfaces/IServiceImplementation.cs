using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APPLib.Services.DTOs;
using APPModels;

namespace APPLib.Services.Interfaces
{
    public interface IServiceImplementation
    {
    //Task<bool> Register(CourseDTO model);
        bool Register(CourseDTO model);
        List<Course> GetResult();
        //Task<List<Course>> GetResult();
    }

    }
