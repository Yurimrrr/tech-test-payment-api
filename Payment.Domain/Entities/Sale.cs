using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class Sale : Entity
    {
        public Sale(DateTime date, Seller seller, List<Product> products, int status)
        {
            Date = date;
            Seller = seller;
            Products = products;
            StatusId = status;
        }

        public Sale()
        {
            
        }

        public DateTime Date { get; private set; }
        public Guid SellerId { get; private set; }
        public Seller Seller { get; set; }
        public List<Product>? Products { get; set; }
        [ForeignKey("StatusSale")]
        public int StatusId { get; set; }
        public virtual StatusSale StatusSale { get; set; }

        public void UpdateStatus(int status)
        {
            StatusId = status;
        }


    }
}
