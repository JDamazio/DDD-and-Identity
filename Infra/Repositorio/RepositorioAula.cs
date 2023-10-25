using Domain.Interfaces.IAula;
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
    public class RepositorioAula : RepositoryGenerics<Aula>, InterfaceAula
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioAula()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Aula>> ListarAulas()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from aulas in banco.Aula
                     select aulas).AsNoTracking().ToListAsync();
            }
        }

        public async Task<Aula> ObterAula(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
