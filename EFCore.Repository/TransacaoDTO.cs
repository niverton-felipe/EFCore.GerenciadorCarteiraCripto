using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class TransacaoDTO
    {
        public string NomeMoeda { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
