using Dominio.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<T> Read(dynamic id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0; 
        }

    public void Update(T entity)
    {
        _context.Update(entity);
    }
}
}
