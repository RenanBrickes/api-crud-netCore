using Repository.Interface;
using Service.Interface;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public void Create(T entity)
        {
            _repository.Create(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public T Read(dynamic id)
        {
            return _repository.Read(id);
        }

        public bool Save()
        {
            return _repository.Save();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
