using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Find(Guid id);
        void InsertOrUpdate(T t);
        void Delete(Guid id);
        void Save();
    }
}
