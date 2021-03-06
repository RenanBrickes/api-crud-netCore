using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBaseRepository<T>
    {
        void Update(T entity);
        void Delete(T entity);
        Task<bool> Save();

    }
}
