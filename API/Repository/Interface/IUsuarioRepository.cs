using Dominio.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUsuarioRepository
    {
        void Alterar(Usuario usuario);
        Task<Usuario> Selecionar(string id);
        void Excluir(Usuario usuario);
        Task<bool> Salvar();
        Task<List<Usuario>> Todos();
        Task<bool> PorEmail(string email);
    }

}
