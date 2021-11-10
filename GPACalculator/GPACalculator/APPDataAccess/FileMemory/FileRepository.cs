using APPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPDataAccess.FileMemory
{
    public class FileRepository : ICRUDRepository
    {
        public FileRepository()
        {

        }
        public bool Add<T>(T entity)
        {
            var course = entity as Course ;
            FileMemory.Write(course);
            if (FileMemory.Write(course))
            {
                return true;
            }
            return false;
        }

        public string Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public int RowCount()
        {
            throw new NotImplementedException();
        }

        public string Update<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
