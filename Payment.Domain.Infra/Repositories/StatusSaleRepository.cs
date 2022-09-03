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

        public StatusSale GetById(Guid id)
        {
            return _context
                .StatusSales
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }   
        
        public StatusSale GetByCodigo(int codigo)
        {
            return _context
               .StatusSales
               .AsNoTracking()
               .FirstOrDefault(x => x.Codigo == codigo);
        }

        public void Update(StatusSale todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
