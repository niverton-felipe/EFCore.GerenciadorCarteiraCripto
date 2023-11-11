using EFCore.Dominio;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.GerenciadorCarteiraCripto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        private readonly TransacaoContext _context;

        public TransacoesController(TransacaoContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult GetAll()
        {
            try {
                return Ok(_context.Transacoes);
            }
            catch (Exception ex){ 
                return BadRequest($"Erro: {ex.Message}");
            }
            
        }

        // GET api/<ValuesController>/5
        [HttpGet("{tipoCompra}")]
        public ActionResult GetByTransaction(string tipoCompra)
        {
            try
            {
                List<Transacao> transacoes = _context.Transacoes.Where(t => t.TipoOperacao == tipoCompra).ToList();

                return Ok(transacoes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }



        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Transacao transacao)
        {
            try
            {

                _context.Transacoes.Add(transacao);
                _context.SaveChanges();
                return Ok("Bazinga");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("soma/{tipoCompra}")]
        public ActionResult GetSumByTransaction(string tipoCompra)
        {
            try
            {
                float soma = _context.Transacoes
                    .Where(t => t.TipoOperacao == tipoCompra)
                    .Sum(t => t.Preco);

                return Ok(new { TipoOperacao = tipoCompra, SomaPreco = soma });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        // PUT api/<ValuesController>/5
        // No controlador

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TransacaoDTO transacaoDTO)
        {
            try
            {
                var transacao = _context.Transacoes.FirstOrDefault(t => t.IdTransacao == id);

                if (transacao != null)
                {
                    // Atualize apenas os campos desejados
                    transacao.NomeMoeda = transacaoDTO.NomeMoeda;
                    transacao.Preco = transacaoDTO.Preco;
                    transacao.Quantidade = transacaoDTO.Quantidade;

                    _context.Transacoes.Update(transacao);
                    _context.SaveChanges();
                }

                return Ok("Bazinga");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _context.Transacoes.Remove(_context
                .Transacoes
                .AsNoTracking()
                .FirstOrDefault(t => t.IdTransacao == id));
                _context.SaveChanges();
                return Ok("Bazinga");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
