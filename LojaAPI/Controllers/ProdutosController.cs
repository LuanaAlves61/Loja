using Domain.Bll;
using Domain.Entities;
using LojaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] //controller/action => nome da controler/nome do método => Ex: Produtos/BuscarTodos
    public class ProdutosController : Controller
    {
        [HttpPost(Name = "PostProdutos")]
        public ActionResult Salvar(ProdutoModel produtoModel)
        {
            try
            {
                var produtoBll = new ProdutoBll();

                Produto produto = new()
                {
                    Nome = produtoModel.Nome,
                    Preco = produtoModel.Preco,
                    UrlImagem = produtoModel.UrlImagem,
                    Descricao = produtoModel.Descricao

                };

                // sinal de negação !, inverte o resultado booleano, ex: !true => false 
                if (!produtoBll.Existe(produto)) 
                {
                    produtoBll.Salvar(produto);
                    return Ok(new { sucess = true, message = "Produto salvo com sucesso" });
                }
                else
                {
                    return Conflict("Produto já existe!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
        
        [HttpGet(Name = "GetProdutos")]
        public List<Produto> BuscarTodos()
        {
            var produtoBll = new ProdutoBll();
            List<Produto> produtos = produtoBll.Listar();

            return produtos;
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public Produto BuscarPorId(int id)
        {
            Produto produto;
            var produtoBll = new ProdutoBll();
            produto = produtoBll.BuscarPorId(id);
          

            return produto ?? new();
            
        }

        [HttpGet]
        public List<Produto> BuscarPorNome([FromQuery] string nome)
        {
            var produtoBll = new ProdutoBll();
            List<Produto> produtos = produtoBll.BuscarPorNome(nome);

            return produtos;
        }
    }

}
