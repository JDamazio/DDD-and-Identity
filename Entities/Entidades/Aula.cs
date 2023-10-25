using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Aula")]
    public class Aula : Base
    {
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string URL { get; set; }
    }
}
