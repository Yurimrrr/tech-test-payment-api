using Payment.Domain.Repositores;

namespace Payment.Domain.Tests.Repositories
{
    public class FakeSaleRepository : ISaleRepository
    {
        public void Create(Payment.Domain.Entities.Sale t)
        {
        }

        public IEnumerable<Payment.Domain.Entities.Sale> GetAll()
        {
            throw new NotImplementedException();
        }

        public Payment.Domain.Entities.Sale GetById(Guid t)
        {
            throw new NotImplementedException();
        }

        public void Update(Payment.Domain.Entities.Sale t)
        {
        }
    }
}
