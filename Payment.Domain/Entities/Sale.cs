using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class Sale : Entity
    {
        public Sale(DateTime date, Seller seller, List<Product> products)
        {
            Date = date;
            Seller = seller;
            Products = products;
            Status = "Aguardando pagamento";
        }

        public Sale()
        {
            
        }

        public DateTime Date { get; private set; }
        public Guid SellerId { get; private set; }
        public Seller? Seller { get; set; }
        public List<Product>? Products { get; set; }
        public string? Status { get; set; }

        public void UpdateStatus(string status)
        {
            Status = status;
        }


    }
}
