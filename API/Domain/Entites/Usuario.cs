using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entites
{
    public class Usuario : IdentityUser
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sexo { get; set; }
        [Required]
        public int Cidade { get; set; }
        [Required]
        public int Estado { get; set; }

        public virtual Cidade Cidade_Fk { get; set; }
    }
}
