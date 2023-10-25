using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuario;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly InterfaceUsuario _interfaceUsuario;

        public UsuarioServico(InterfaceUsuario interfaceUsuario)
        {
            _interfaceUsuario = interfaceUsuario;
        }

        public async Task CadastrarUsuario(Object _usuario)
        {
            await _interfaceUsuario.Add((UsuarioDetail)_usuario);
        }
    }
}
