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

        [HttpPost]

        public IActionResult InserirProduto(ProdutosAll Model)
        {
            SqlHelper.InsertProduto(Model);
            return Ok();
        }
    }
}
