namespace Domain.Entities
{
    public class Produto
    {   
        public int Id { get; set; } 
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string UrlImagem { get; set; }
        public string Descricao { get; set; }
    }
}
