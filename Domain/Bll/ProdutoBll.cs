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
           produtoDal.Salvar(produto);
        }

        public List<Produto> Listar()
        { 
            return produtoDal.Listar();
        }

        public Produto BuscarPorId(int id)
        {
            return produtoDal.BuscarPorId(id);
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            return produtoDal.BuscarPorNome(nome);
        }
    }
}
