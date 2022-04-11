using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUsuarioService
    {
        Task<Resposta> Create(UsuarioCreateView usuarioCreate);
        Task<Resposta> PorEmail(string email);
    }
}
