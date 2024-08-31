using Dapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dal
{
    internal class ProdutoDal
    {

        private string connectionString;

         public ProdutoDal()
        {
            connectionString = "Data Source=DESKTOP-PBPI94C;Initial Catalog=Loja;Integrated Security=True;Connect Timeout=30;";    
        }

        public void Salvar(Produto produto)
        {
            var sql = @"
            insert into Produtos (Nome, Preco, UrlImagem, Descricao) values 
            (@Nome, @Preco, @UrlImagem, @Descricao);
            ";

            using (var connection = new SqlConnection(connectionString)) 
            { 
                connection.Open();
                connection.Execute(sql, new
                {
                    produto.Nome,
                    produto.Preco,
                    produto.UrlImagem,
                    produto.Descricao
                } );
            }
        }

        public List<Produto> Listar()
        {
            var sql = @"
                SELECT
                       Id,
                       Nome, 
                       Preco,
                       UrlImagem, 
                       Descricao
                FROM
                       Produtos;
            ";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<Produto> retorno = connection.Query<Produto>(sql).ToList();
                return retorno; 
            }
          
        }
        public Produto BuscarPorId(int id)
        {
            var sql = @"
                SELECT
                       Id,
                       Nome, 
                       Preco,
                       UrlImagem, 
                       Descricao
                FROM
                       Produtos
					   where id = @id_produto
            ";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Produto retorno = connection.Query<Produto>(sql, new { id_produto = id}).FirstOrDefault();
                return retorno;
            }   
        }

        internal List<Produto> BuscarPorNome(string nome)
        {
            var sql = @"
                SELECT
                       Id,
                       Nome, 
                       Preco,
                       UrlImagem, 
                       Descricao
                FROM
                       Produtos
				WHERE 
					   Nome like '%' + @nome + '%' 
            ";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<Produto> retorno = connection.Query<Produto>(sql, new { nome}).ToList();
                return retorno;
            }

        }
    }

}
