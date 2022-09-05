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

        public StatusSale GetByCodigo(int codigo)
        {
            return new StatusSale();
        }

        public Payment.Domain.Entities.StatusSale GetById(Guid t)
        {
            return new StatusSale();
        }

        public void Update(Payment.Domain.Entities.StatusSale t)
        {
        }
    }
}
