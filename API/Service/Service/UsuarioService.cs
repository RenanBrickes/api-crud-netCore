using Dominio.Entites;
using Microsoft.AspNetCore.Identity;
using Repository.Interface;
using Service.Interface;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UsuarioService : IUsuarioService
    {
        readonly IUsuarioRepository _usuarioRepository;
        readonly UserManager<Usuario> _userManager;

        public UsuarioService(IUsuarioRepository usuarioRepository, UserManager<Usuario> usuario)
        {
            _usuarioRepository = usuarioRepository;
            _userManager = usuario;
        }

        public async Task<Resposta> Create(UsuarioCreateView usuarioCreate)
        {
            try
            {
                string senha = NovaSenha();
                //Define classe para inclusão de usuário
                Usuario novoUsuario = new Usuario
                {
                    UserName = usuarioCreate.Email,
                    Cidade = usuarioCreate.Cidade,
                    PhoneNumber = usuarioCreate.Celular ?? usuarioCreate.Telefone,
                    Email = usuarioCreate.Email,
                    Sexo = usuarioCreate.Sexo,
                    PasswordHash = senha
                };

                //Tenta criar o usuário
                IdentityResult incluirUsuario = await _userManager.CreateAsync(novoUsuario, senha);

                //Verifia se a inclusão do usuário
                if (incluirUsuario.Succeeded)
                    return new Resposta(true, "Usuário cadastrado com sucesso, em seu email chegara informações para o login");
                else
                {
                    List<string> listaErros = incluirUsuario.Errors.Select(e => e.Description).ToList();
                    string erros = string.Empty;
                    foreach (string erro in listaErros)
                    {
                        erros += erro;
                    }

                    return new Resposta(false, erros);
                }
            }
            catch
            {
                return new Resposta(false, string.Empty);
            }
        }

        public async Task<Resposta<Usuario>> Get(string id)
        {
            try
            {
                //Seleciona o usuário
                Usuario usuario = await _usuarioRepository.Selecionar(id);
                //Verifia se não houve retorno
                if (usuario is null)
                    return new Resposta<Usuario>(false, "Não há usuário para esse ID");

                return new Resposta<Usuario>(true, string.Empty, usuario);

            }
            catch
            {
                return new Resposta<Usuario>(false, string.Empty);
            }
        }

        public async Task<Resposta> Edit(Usuario usuario)
        {
            try
            {
                //Altera modelo
                _usuarioRepository.Alterar(usuario);
                //Salva resultado
                bool resultado = await _usuarioRepository.Salvar();

                return new Resposta(resultado, string.Empty);
            }
            catch
            {
                return new Resposta(false, string.Empty);
            }
        }

        public async Task<Resposta> Delete(Usuario usuario)
        {
            try
            {
                //Exclui o usuário
                _usuarioRepository.Excluir(usuario);
                bool resultado = await _usuarioRepository.Salvar();

                return new Resposta(resultado, string.Empty);
            }
            catch
            {
                return new Resposta(false, string.Empty);
            }
        }

        public async Task<RespostaLista<UsuarioDetalheView>> GetAll()
        {
            try
            {
                //Seleciona todos usuarios
                List<Usuario> usuarios = await _usuarioRepository.Todos();

                //Monta lista para retornar dados
                List<UsuarioDetalheView> usuariosDetalhe = usuarios.Select(u => new UsuarioDetalheView(u))
                    .ToList();

                //Retorna lista para
                return new RespostaLista<UsuarioDetalheView>(true, string.Empty, usuariosDetalhe);
            }
            catch
            {
                return new RespostaLista<UsuarioDetalheView>(false);

            }
        }

        public async Task<Resposta> PorEmail(string email)
        {
            //Chama rotina asyn que busca o usuário por email 
            bool resultado = await _usuarioRepository.PorEmail(email);

            return new Resposta(resultado, resultado ? "Já existe um usuário com esse email." : "");
        }

        private static string NovaSenha(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

    }
}
