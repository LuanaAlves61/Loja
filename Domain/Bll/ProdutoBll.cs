using Domain.Dal;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bll
{
    public class ProdutoBll
    {
        private ProdutoDal produtoDal;

        public ProdutoBll()
        {
            produtoDal = new Dal.ProdutoDal();
        }
        public void Salvar(Produto produto)
        {
            if (produto.Id != 0)
                produtoDal.Atualizar(produto);
            else
                produtoDal.Inserir(produto);
        }

        public List<Produto> Listar()
        { 
            return produtoDal.Listar();
        }

        /// <summary>
        /// busca o produto pelo id
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <returns>retorna 1 produto</returns>
        public Produto BuscarPorId(int id)
        {
            return produtoDal.BuscarPorId(id);
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            return produtoDal.BuscarPorNome(nome);
        }

        public bool Existe(Produto produto)
        {
            return produtoDal.Existe(produto.Nome);
        }
        public bool Existe(int id)
        {
            return produtoDal.BuscarPorId(id) != null;
        }
    }
}
