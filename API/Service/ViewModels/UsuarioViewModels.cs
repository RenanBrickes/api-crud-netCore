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
}
