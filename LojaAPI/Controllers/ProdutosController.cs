using Domain.Bll;
using Domain.Entities;
using LojaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        [HttpPost(Name = "PostProdutos")]
        public ActionResult Post(ProdutoModel produtoModel)
        {
            var produtoBll = new ProdutoBll();
            
            Produto produto = new()
            {
                Nome = produtoModel.Nome,
                Preco = produtoModel.Preco,
                UrlImagem = produtoModel.UrlImagem,
                Descricao = produtoModel.Descricao

            };

            produtoBll.Salvar(produto);

            return Ok(new {sucess = true, message = "Produto salvo com sucesso"});
        }

        [HttpGet(Name = "GetProdutos")]
        public List<Produto> GetProdutos()
        {
            var produtoBll = new ProdutoBll();
            List<Produto> produtos = produtoBll.Listar();

            return produtos;
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public Produto GetProduto(int id)
        {
            Produto produto;
            var produtoBll = new ProdutoBll();
            produto = produtoBll.BuscarPorId(id);
          

            return produto ?? new();
            
        }

        [HttpGet("PorNome")]
        public List<Produto> GetProdutosPorNome([FromQuery] string nome)
        {
            var produtoBll = new ProdutoBll();
            List<Produto> produtos = produtoBll.BuscarPorNome(nome);

            return produtos;
        }
    }

}
