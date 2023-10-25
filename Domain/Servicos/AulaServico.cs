using Domain.Interfaces.IAula;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class AulaServico : IAulaServico
    {
        private readonly InterfaceAula _interfaceAula;
        public AulaServico(InterfaceAula interfaceAula)
        {
            _interfaceAula = interfaceAula;
        }

        public async Task AdicionarAula(Aula aula)
        {
            var data = DateTime.UtcNow;

            aula.DataCriacao = data;
            var valido = aula.ValidarPropriedadeString(aula.Nome, "Nome"); // Depois analizar a melhor opc
            if (valido)
                await _interfaceAula.Add(aula);
        }

        public async Task AtualizarAula(Aula aula)
        {
            var data = DateTime.UtcNow;
            aula.DataModificacao = data;

            var valido = aula.ValidarPropriedadeString(aula.Nome, "Nome"); // Depois analizar a melhor opc
            if (valido)
                await _interfaceAula.Update(aula);
        }
    }
}
