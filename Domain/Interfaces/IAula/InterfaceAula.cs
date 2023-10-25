using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IAula
{
    public interface InterfaceAula : InterfaceGeneric<Aula>
    {
        Task<IList<Aula>> ListarAulas();
        Task<Aula> ObterAula(Guid id);
    }
}
