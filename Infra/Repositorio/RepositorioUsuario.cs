using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuario;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioUsuario : RepositoryGenerics<UsuarioDetail>, InterfaceUsuario
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUsuario()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<UsuarioDetail>> ListarUsuarios()
        {
            using ( var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from usuarios in banco.UsuarioDetail
                     select usuarios).AsNoTracking().ToListAsync();
            }
        }

        public async Task<UsuarioDetail> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    banco.UsuarioDetail.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(emailUsuario));
            }
        }

        public async Task<Aula> AulaAtual(Guid usuarioId)
        {
            using ( var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from aula in banco.Aula
                     join Usuario in banco.UsuarioDetail on aula.Id equals Usuario.AulaId
                     where Usuario.Id == usuarioId
                     select aula).AsNoTracking().FirstOrDefaultAsync();
            }
        }
    }
}
