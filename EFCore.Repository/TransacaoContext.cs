using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class TransacaoContext : DbContext
    {
        public TransacaoContext(DbContextOptions<TransacaoContext> options) : base(options) { }
        public DbSet<Moeda> Moedas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
