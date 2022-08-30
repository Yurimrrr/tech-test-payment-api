using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Repositories.Generic
{
    public interface IRepository<T>
    {
        void Create(T t);

        void Update(T t);

        T GetById(Guid t);

        IEnumerable<T> GetAll();
    }
}
