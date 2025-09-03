using ProjetoWebSales.Models.Enums;

namespace ProjetoWebSales.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        { 
        }

        public SalesRecord( DateTime date, double v, SaleStatus status, Seller seller)
        {
            Date = date;
            Status = status;
            Seller = seller;
        }
    }
}
