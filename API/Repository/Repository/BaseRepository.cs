using Dominio.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T Read(dynamic id)
        {
            return _context.Users.Find(id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0; 
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
