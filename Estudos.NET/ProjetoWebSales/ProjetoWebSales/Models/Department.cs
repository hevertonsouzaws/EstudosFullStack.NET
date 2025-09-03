using System.Collections.Generic;
using System.Linq;

namespace ProjetoWebSales.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(string? name)
        {
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        // Função que soma o total de vendas para cada vendedor na lista de vendedores em determinado periodo 
        public double TotalSales(DateTime initial, DateTime final)
        {
           return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
