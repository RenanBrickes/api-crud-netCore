using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IBaseService<T> where T : class
    {
        void Create(T entity);
        T Read(dynamic id);
        void Update(T entity);
        void Delete(T entity);
        bool Save();
    }
}
