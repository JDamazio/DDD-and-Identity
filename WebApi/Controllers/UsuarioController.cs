using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuario;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly InterfaceUsuario _interfaceUsuario;
        private readonly IUsuarioServico _iusuarioServico;
        public UsuarioController(InterfaceUsuario interfaceUsuario, IUsuarioServico usuarioServico)
        {
            _interfaceUsuario = interfaceUsuario;
            _iusuarioServico = usuarioServico;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("/api/ListarUsuarios")]
        [Produces("application/json")]
        public async Task<IList<UsuarioDetail>> ListaUsuarios()
        {
            return await _interfaceUsuario.ListarUsuarios();
        }

        [HttpPost("/api/CadastrarUsuario")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuario(UsuarioDetail usuario)
        {
            try
            {
                await _iusuarioServico.CadastrarUsuario(
                new UsuarioDetail
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Idade = usuario.Idade,
                    Altura = usuario.Altura,
                    Sexo = usuario.Sexo,
                    Plano = usuario.Plano,
                    Administrador = false,
                    DataCriacao = DateTime.UtcNow
                });
            }
            catch(Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        [HttpDelete("/api/DeletarUsuario")]
        [Produces("application/json")]
        public async Task<object> DeletarUsuario(Guid usuarioId)
        {
            try
            {
                var usuario = await _interfaceUsuario.GetEntityById(usuarioId);
                await _interfaceUsuario.Delete(usuario);
            }
            catch(Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
