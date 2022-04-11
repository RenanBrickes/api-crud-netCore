using Dominio.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        Usuario Selecionar(string id);
        void Excluir(Usuario usuario);
        IEnumerable<Usuario> Todos();

    }
    
}
