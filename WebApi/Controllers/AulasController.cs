using Domain.Interfaces.IAula;
using Domain.Interfaces.InterfaceServicos;
using Domain.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AulasController : ControllerBase
    {
        private readonly InterfaceAula _interfaceAula;
        private readonly IAulaServico _aulaServico;

        public AulasController(InterfaceAula interfaceAula, IAulaServico aulaServico)
        {
            _interfaceAula = interfaceAula;
            _aulaServico = aulaServico;
        }

        [HttpGet("/api/ListagemAulas")]
        [Produces("application/json")]
        public async Task<IList<Aula>> ListarAulas()
        {
            return await _interfaceAula.ListarAulas();
        }

        [HttpPost("/api/AdicionarAula")]
        [Produces("application/json")]
        public async Task<object> AdicionarAula(Aula aula)
        {
            await _aulaServico.AdicionarAula(aula);
            return Task.FromResult(aula);
        }

        [HttpPut("/api/AtualizarAula")]
        [Produces("application/json")]
        public async Task<object> AtualizarAula(Aula aula)
        {
            await _aulaServico.AtualizarAula(aula);
            return Task.FromResult(aula);
        }

        [HttpGet("/api/ObterAula")]
        [Produces("application/json")]
        public async Task<object> ObterAula(Guid id)
        {
            return await _interfaceAula.GetEntityById(id);
        }

        [HttpDelete("/api/DeletarAula")]
        [Produces("application/json")]
        public async Task<object> DeletarAula(Guid id)
        {
            try
            {
                var aula = await _interfaceAula.GetEntityById(id);
                await _interfaceAula.Delete(aula);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
