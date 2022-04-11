using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        T Read(dynamic id);
        void Update(T entity);
        void Delete(T entity);
        bool Save();

    }
}
