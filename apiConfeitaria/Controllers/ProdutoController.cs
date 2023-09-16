using apiConfeitaria.Models.Produtos;
using Microsoft.AspNetCore.Mvc;

namespace apiConfeitaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var Produtos = SqlHelper.GetProductAll();
            return Ok(Produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var Produtos = SqlHelper.GetProductById(id);
            return Ok(Produtos);
        }

        [HttpPost]

        public IActionResult InserirProduto(ProdutosAll Model)
        {
            SqlHelper.InsertProduto(Model);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateProduto(int id, ProdutosAll Model)
        {
            //chamar func update
            SqlHelper.UpdateProduto(Model, id);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduto(int id)
        {
            //chamar func update
            SqlHelper.DeleteProduto(id);
            return Ok();
        }
    }
}
