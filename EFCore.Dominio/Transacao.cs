using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class Transacao
    {
        [Key]
        public int IdTransacao { get; set; }
        public string NomeMoeda { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
        public string TipoOperacao { get; set; }

        public DateTime DataTrasacao { get; set; }
    }
}
