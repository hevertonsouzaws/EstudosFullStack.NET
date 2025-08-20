namespace PrimeiroPrograma
{
    internal class Produto
    {
        public string Descrição;
        public double Preco;
        public int Quantidade;

        /* Construtor
        public Produto(string nome, double preco, int quantidade)
        {
            nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        } */

        public double ValorTotalEmEstoque()
        {
            return Preco * Quantidade;
        }

        public void AdicionarProduto(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void RemoverProduto(int quantidade)
        {
            Quantidade -= quantidade;
        }


        // Método para exibir as informações do produto 
        public override string ToString()
        {
            return Descrição 
                + "\n | preço: R$ " 
                + Preco.ToString("F2")
                + "\n | estoque: "
                + Quantidade
                + "\n | valor total: R$ "
                + ValorTotalEmEstoque();
        }
      
    }
}
