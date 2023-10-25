using Entities.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class Base : Notifica
    {
        [Display(Name = "Código")]
        public Guid Id { get; set; }
        public DateTime? DataModificacao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
