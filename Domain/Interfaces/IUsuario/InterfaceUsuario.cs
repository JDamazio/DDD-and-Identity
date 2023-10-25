using Domain.Interfaces.Generics;
using Entities.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUsuario
{
    public interface InterfaceUsuario : InterfaceGeneric<UsuarioDetail>
    {
        Task<IList<UsuarioDetail>> ListarUsuarios();
        Task<UsuarioDetail> ObterUsuarioPorEmail(string emailUsuario);
        Task<Aula> AulaAtual(Guid usuarioId);
    }
}
