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
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Product user)
        {
            _context.Products.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context
                .Products
                .AsNoTracking()
                .OrderBy(x => x.DateRegistration);
        }

        public Product GetById(Guid id)
        {
            return _context
                .Products
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }    

        public void Update(Product todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
