using Payment.Domain.Entities;
using Payment.Domain.Repositores;

namespace Payment.Domain.Tests.Repositories
{
    public class FakeStatusSaleRepository : IStatusSaleRepository
    {
        public void Create(Payment.Domain.Entities.StatusSale t)
        {
        }

        public IEnumerable<Payment.Domain.Entities.StatusSale> GetAll()
        {
            throw new NotImplementedException();
        }

        public Payment.Domain.Entities.StatusSale GetById(int t)
        {
            return new StatusSale();
        }

        public StatusSale GetById(Guid t)
        {
            throw new NotImplementedException();
        }

        public void Update(Payment.Domain.Entities.StatusSale t)
        {
        }
    }
}
