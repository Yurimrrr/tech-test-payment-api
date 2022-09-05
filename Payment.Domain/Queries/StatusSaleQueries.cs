using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Entities;

namespace Payment.Domain.Queries
{
    public static class StatusSaleQueries
    {
        
        public static Expression<Func<StatusSale, bool>> GetByCodigo(int codigo)
        {
            return x => x.Codigo == codigo;
        }
        

    }

}
