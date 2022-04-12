using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> Create(UsuarioCreateView usuarioCreate)
        {
            //Valida modelo de inclusão
            if (ModelState.IsValid)
            {
                //Verifica se não existe um usuário com o mesmo email cadastrado
                Resposta emailDuplicado = await _usuarioService.PorEmail(usuarioCreate.Email);

                //Se houver um usuário com o mesmo email
                if (emailDuplicado.Resultado)
                    return Ok(emailDuplicado);

                //Chama rotina para inclusão do usuário
                Resposta usuarioIncluido = await _usuarioService.Create(usuarioCreate);
                return Ok(usuarioIncluido);
            }

            return Ok(new Resposta(false, ""));
        }

        [HttpPut("/edit")]
        public async Task<IActionResult> Edit(UsuarioEditView usuarioEdit)
        {
            //Verifica se usuário existe como ID informado
            Resposta<Usuario> usuarioExiste = await _usuarioService.Get(usuarioEdit.ID);

            //Se usuário não exisitir, retorna erro
            if (!usuarioExiste.Resultado)
                return Ok(usuarioExiste);

            //Monta a classe para alteração dos dados
            Usuario usuarioAlterar = usuarioEdit.ParaUsuario(usuarioExiste.Modelo);

            //Tenta alterar os dados
            Resposta resposta = await _usuarioService.Edit(usuarioAlterar);

            //Retorna 
            return Ok(resposta);
        }

        [HttpGet("/details")]
        public async Task<IActionResult> Details(string id)
        {
            //Verifia se o id do usuário é valido
            if (string.IsNullOrEmpty(id))
                return Ok(new Resposta(false, "Informe um ID valido para consulta de usuário"));

            //Faz a busca de usuário
            Resposta<Usuario> respostaUsuario = await _usuarioService.Get(id);

            //Verifica se encontrou o usuário com o id
            if(!respostaUsuario.Resultado)
                return Ok(new Resposta(false, "Informe um ID valido para consulta de usuário"));
            
            //Separa apenas os dados para retorno
            UsuarioDetalheView usuarioDetalhe = new UsuarioDetalheView(respostaUsuario.Modelo);
            //Retorna dados de busca de usuário
            return Ok(new Resposta<UsuarioDetalheView>(respostaUsuario.Resultado, string.Empty, usuarioDetalhe));        
        }

        [HttpDelete("/delete")]
        public async Task<IActionResult> Delete(string id)
        {
            //Verifia se o id do usuário é valido
            if (string.IsNullOrEmpty(id))
                return Ok(new Resposta(false, "Informe um ID valido para consulta de usuário"));

            //Faz a busca de usuário
            Resposta<Usuario> respostaUsuario = await _usuarioService.Get(id);

            //Verifica se encontrou o usuário com o id
            if (!respostaUsuario.Resultado)
                return Ok(new Resposta(false, "Informe um ID valido para consulta de usuário"));

            //Faz a busca de usuário
            Resposta respotaExclusao = await _usuarioService.Delete(respostaUsuario.Modelo);

            //Retorna o resultado da oparação
            return Ok(respotaExclusao);

        }

        [HttpGet("/details/all")]
        public async Task<IActionResult> GetAll()
        {
            //Pega lista de usuários
            RespostaLista<UsuarioDetalheView> usuarios = await _usuarioService.GetAll();

            return Ok(usuarios);
        }
    }
}
