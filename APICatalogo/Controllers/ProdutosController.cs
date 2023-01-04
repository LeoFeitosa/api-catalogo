using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using APICatalogo.Context;
using APICatalogo.Models;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = this._context.Produtos.ToList();
            if (produtos is null)
            {
                return NotFound("Produtos nao encontrados");
            }

            return produtos;

        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = this._context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto nao encontrado");
            }

            return produto;
        }
    }
}   