using Dominio.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class UsuarioViewModels
    {
    }

    public class UsuarioCreateView
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório.")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo cidade é obrigatório.")]
        public int Cidade { get; set; }

        [Required(ErrorMessage = "O campo sexo é obrigatório.")]
        public string Sexo { get; set; }
    }

    public class UsuarioEditView
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int? Cidade { get; set; }
        public string Sexo { get; set; }

        public Usuario ParaUsuario(Usuario usuario)
        {
            usuario.Nome = string.IsNullOrEmpty(Nome) ? usuario.Nome : Nome;
            usuario.Email = string.IsNullOrEmpty(Email) ? usuario.Email : Email;
            usuario.PhoneNumber = string.IsNullOrEmpty(Telefone) ? string.IsNullOrEmpty(Celular) ? usuario.PhoneNumber : Celular : Telefone; 
            usuario.Cidade = Cidade.HasValue ? Cidade.Value : usuario.Cidade;
            usuario.Sexo = string.IsNullOrEmpty(Sexo) ? usuario.Sexo: Sexo;

            return usuario;
        }

    }

    public class UsuarioDetalheView 
    {
        public UsuarioDetalheView(Usuario usuario)
        {
            Nome = usuario.Nome;
            ID = usuario.Id;
            Email = usuario.Email;
            Celular = usuario.PhoneNumber;
            Cidade = new IdNomeViewModels(usuario.Cidade, usuario.Cidade_Fk.Nome);
            Sexo = usuario.Sexo;
        }

        public string Nome { get; set; }
        public string ID { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public IdNomeViewModels Cidade { get; set; }
        public string Sexo { get; set; }

    
    }



}
