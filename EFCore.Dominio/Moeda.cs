using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class Moeda
    {
        [Key]
        public int IdMoeda { get; set; }
        public string NomeMoeda { get; set; }
        public float PrecoMoeda { get; set; }
    }
}
