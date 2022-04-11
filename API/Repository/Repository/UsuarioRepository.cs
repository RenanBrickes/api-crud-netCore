using Dominio.Context;
using Dominio.Entites;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context)
        {
        }

        public void Adicionar(Usuario usuario)
        {
            Create(usuario);
        }

        public void Alterar(Usuario usuario)
        {
            Update(usuario);
        }

        public void Excluir(Usuario usuario)
        {
            Delete(usuario);
        }

        public Usuario Selecionar(string id)
        {
            return Read(id);
        }

        public IEnumerable<Usuario> Todos()
        {
            return _context.Users.AsEnumerable();
        }
    }
}
