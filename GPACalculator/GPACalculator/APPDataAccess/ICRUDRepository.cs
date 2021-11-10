using APPModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPDataAccess
{
    public interface ICRUDRepository
    {
        bool Add<T>(T entity);
        string Update<T>(T entity);
        string Delete<T>(T entity);
        int RowCount();
        //public Task<List<Course>> Get();
    }
}
