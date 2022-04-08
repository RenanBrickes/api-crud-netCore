using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entites
{
    [Table("Cidade")]
    public class Cidade
    {
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int CodigoIBGE { get; set; }

        [Required]
        public int Estado { get; set; }

        public virtual Estado Estado_fk { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
