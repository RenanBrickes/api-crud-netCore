using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entites
{
    [Table("Estado")]
    public class Estado
    {
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int CodigoIBGE { get; set; }

        public ICollection<Cidade> Cidade { get; set; }
    }
}
