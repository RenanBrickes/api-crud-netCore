using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ViewModels
{
    public class Resposta
    {
        public Resposta(bool resultado, string mensagem = "")
        {
            Resultado = resultado;
            Mensagem = DefineMensagem(mensagem);
        }

        public bool Resultado { get; set; }
        public string Mensagem { get; set; }

        private string DefineMensagem(string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
            {
                if (Resultado)
                    return "Operação realizada com sucesso!";
                else
                    return "Não foi possivél realizar a operação, tente novamente ou mais tarde!";
            }
            else
                return mensagem;
        }
    }

    public class Resposta<T> where T : class
    {
        public Resposta(bool resultado, string mensagem = "", T modelo = null)
        {
            Resultado = resultado;
            Mensagem = DefineMensagem(mensagem);
            Modelo = modelo;
        }

        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
        public T Modelo { get; set; }
        private string DefineMensagem(string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
            {
                if (Resultado)
                    return "Operação realizada com sucesso!";
                else
                    return "Não foi possivél realizar a operação, tente novamente ou mais tarde!";
            }
            else
                return mensagem;
        }
    }

    public class RespostaLista<T> where T : class
    {
        public RespostaLista(bool resultado, string mensagem = "", List<T> modelo = null)
        {
            Resultado = resultado;
            Mensagem = DefineMensagem(mensagem);
            Modelo = modelo;
        }

        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
        public List<T> Modelo { get; set; }
        private string DefineMensagem(string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
            {
                if (Resultado)
                    return "Operação realizada com sucesso!";
                else
                    return "Não foi possivél realizar a operação, tente novamente ou mais tarde!";
            }
            else
                return mensagem;
        }
    }
}
