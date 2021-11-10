using APPModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APPDataAccess.InMemoryRepository.Interface
{
    public interface IResultRepository : ICRUDRepository
    {
        Course SelectCourse(int Id);
        //Task<List<Course>> GetResult();
        List<Course> GetResult();
    }
}
