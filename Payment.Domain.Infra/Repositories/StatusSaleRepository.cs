using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Entities;
using Payment.Domain.Infra.Contexts;
using Payment.Domain.Queries;
using Payment.Domain.Repositores;

namespace Payment.Domain.Infra.Repositories
{
    public class StatusSaleRepository : IStatusSaleRepository
    {
        private readonly DataContext _context;

        public StatusSaleRepository(DataContext context)
        {
            _context = context;

            if (!context.StatusSales.Any())
            {
                var status = new List<StatusSale>()
                {
                    new StatusSale(1,"Aguardando Pagamento"),
                    new StatusSale(2,"Pagamento Aprovado"),
                    new StatusSale(3,"Enviado Transportadora"),
                    new StatusSale(4,"Cancelado"),
                    new StatusSale(5,"Entregue")
                };

                context.StatusSales.AddRange(status);

                context.SaveChanges();

            }
        }

        public void Create(StatusSale user)
        {
            _context.StatusSales.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<StatusSale> GetAll()
        {
            return _context
                .StatusSales
                .AsNoTracking()
                .OrderBy(x => x.DateRegistration);
        }

        public StatusSale GetById(int id)
        {
            return _context
                .StatusSales
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }   
        

        public void Update(StatusSale todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public StatusSale GetById(Guid t)
        {
            throw new NotImplementedException();
        }
    }
}
