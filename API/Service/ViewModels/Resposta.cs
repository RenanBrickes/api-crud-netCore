using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ViewModels
{
    public class Resposta
    {
        public Resposta(bool resultado, string mensagem)
        {
            Resultado = resultado;
            Mensagem = mensagem;
        }

        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
        private string MensagemFormatada => string.IsNullOrEmpty(Mensagem) ? 
            Resultado ? "Operação realizada com sucesso!" : "Não foi possivél realizar a operação, tente novamente ou mais tarde" 
                    : Mensagem;
    }

    public class Resposta<T> where T : class
    {
        public Resposta(bool resultado, string mensagem, List<T> lista)
        {
            Resultado = resultado;
            Mensagem = mensagem;
            Lista = lista;
        }

        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
        public List<T> Lista { get; set; } 
        private string MensagemFormatada => string.IsNullOrEmpty(Mensagem) ?
            Resultado ? "Operação realizada com sucesso!" : "Não foi possivél realizar a operação, tente novamente ou mais tarde"
                    : Mensagem;
    }
}
