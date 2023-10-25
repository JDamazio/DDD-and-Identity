using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("UsuarioDetail")]
    public class UsuarioDetail : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public string Altura { get; set; }
        public char Sexo { get; set; }
        public bool Pago { get; set; }
        public Enums.EnumPlano Plano { get; set; }
        public bool Administrador { get; set; }

        [ForeignKey("Aula")]
        [Column(Order = 1)]
        public Guid? AulaId { get; set; }
        public virtual Aula? Aula { get; set; }

        [ForeignKey("IdentityUser")]
        public Guid UserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}
