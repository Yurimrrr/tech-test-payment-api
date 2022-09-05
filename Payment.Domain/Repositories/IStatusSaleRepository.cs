using Payment.Domain.Entities;
using Payment.Domain.Repositories.Generic;

namespace Payment.Domain.Repositores
{
    public interface IStatusSaleRepository : IRepository<StatusSale>
    {
        StatusSale GetById(int id);
    }
}
