﻿using Microsoft.EntityFrameworkCore;
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
    public class SaleRepository : ISaleRepository
    {
        private readonly DataContext _context;

        public SaleRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Sale user)
        {
            _context.Sales.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<Sale> GetAll()
        {
            return _context
                .Sales
                .AsNoTracking()
                .Include(x => x.Products)
                .Include(x => x.Seller)
                .OrderBy(x => x.DateRegistration);
        }

        public Sale GetById(Guid id)
        {
            return _context
                .Sales
                .AsNoTracking()
                .Include(x => x.Products)
                .Include(x => x.Seller)
                .FirstOrDefault(x => x.Id == id);
        }    

        public void Update(Sale todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}