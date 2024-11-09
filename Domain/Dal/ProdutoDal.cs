using Dapper;
using Domain.Entities;
using Npgsql;

namespace Domain.Dal
{
    internal class ProdutoDal
    {
        private string connectionString;

        public ProdutoDal()
        {
            connectionString = "Host=c3gtj1dt5vh48j.cluster-czrs8kj4isg7.us-east-1.rds.amazonaws.com;Port=5432;Username=u860ivsbd1jsvv;Password=p7ea8ed84051854c89a2640422a245ccdccfa07bc7aa0094ef708ef67fee661a8;Database=dc1n89slqd6av1;";
        }

        public void Inserir(Produto produto)
        {
            var sql = @"
            INSERT INTO Produtos (Nome, Preco, UrlImagem, Descricao) VALUES 
            (@Nome, @Preco, @UrlImagem, @Descricao);
            ";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql, new
                {
                    produto.Nome,
                    produto.Preco,
                    produto.UrlImagem,
                    produto.Descricao
                });
            }
        }
        public void Atualizar(Produto produto)
        {
            var sql = @"
                update produtos set 
                Nome = @Nome,
                Preco = @Preco,
                UrlImagem = @UrlImagem,
                Descricao = @Descricao
                where id = @pid
            ";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql, new
                {   
                    pid = produto.Id,
                    produto.Nome,
                    produto.Preco,
                    produto.UrlImagem,
                    produto.Descricao
                });
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
            using (var connection = new NpgsqlConnection(connectionString))
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
                WHERE id = @id_produto
            ";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                Produto retorno = connection.Query<Produto>(sql, new { id_produto = id }).FirstOrDefault();
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
                       Nome ILIKE '%' || @nome || '%'
            ";
            using (var connection = new NpgsqlConnection(connectionString)) 
            {
                connection.Open();
                List<Produto> retorno = connection.Query<Produto>(sql, new { nome }).ToList();
                return retorno;
            }
        }

        internal bool Existe(string nome)
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
                       Nome ILIKE @nome 
            ";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                List<Produto> produtosRetornados = connection.Query<Produto>(sql, new { nome }).ToList();
                return produtosRetornados.Count > 0;
            }
        }
    }
}
