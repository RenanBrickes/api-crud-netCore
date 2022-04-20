using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ViewModels
{
    public class IdNomeViewModels
    {
        public IdNomeViewModels(int iD, string nome)
        {
            ID = iD;
            Nome = nome;
        }

        public int ID{ get; set; }

        public string Nome { get; set; }
    }
}
