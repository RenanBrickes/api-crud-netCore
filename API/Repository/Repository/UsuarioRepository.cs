using Dominio.Context;
using Dominio.Entites;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context)
        {
        }

        public void Alterar(Usuario usuario)
        {
            Update(usuario);
        }

        public void Excluir(Usuario usuario)
        {
            Delete(usuario);
        }

        public async Task<bool> PorEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).CountAsync() > 0;
        }

        public async Task<bool> Salvar()
        {
            return await Save();
        }

        public async Task<Usuario> Selecionar(string id)
        {
            return await Read(id);
        }

        public IEnumerable<Usuario> Todos()
        {
            return _context.Users.AsEnumerable();
        }
    }
}
