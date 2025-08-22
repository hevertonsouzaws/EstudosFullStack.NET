namespace PrimeiroPrograma
{
    internal class Produto
    {
        private string _descricao;
        private double _preco;
        private int _quantidade;

   
        public Produto(string descricao, double preco, int quantidade)
        {
            _descricao = descricao;
            _preco = preco;
            _quantidade = quantidade;
        }

        public double ValorTotalEmEstoque()
        {
            return _preco * _quantidade;
        }

        public void AdicionarProduto(int quantidade)
        {
            _quantidade += quantidade;
        }

        public void RemoverProduto(int quantidade)
        {
            _quantidade -= quantidade;
        }

        // Get e set sem propiedades
        /*
        public string GetDescricao()
        {
            return _descricao;
        }

        public void SetDescricao(string descricao)
        {
            if (descricao != null && descricao.Length > 1 )
            {
                _descricao = descricao;
            } 
        } */

        //Get e Set com propiedade

        public string Descricao 
        {
            get { return _descricao; }
            set
            {
                if (value != null && value.Length > 1)
                {
                    _descricao = value;
                }
            }
        }

        public double Preco
        {
            get { return _preco; }
        }

        public int Quantidade
        {
            get { return _quantidade; }
        }

        // Método para exibir as informações do produto 
        public override string ToString()
        {
            return _descricao 
                + "\n | preço: R$ " 
                + _preco.ToString("F2")
                + "\n | estoque: "
                + _quantidade
                + "\n | valor total: R$ "
                + ValorTotalEmEstoque();
        }
      
    }
}
