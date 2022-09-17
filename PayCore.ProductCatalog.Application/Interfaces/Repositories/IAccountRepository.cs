using PayCore.ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task Create(Account entity);
        Task Update(Account entity);
        Task Delete(Account entity);
        Task<IEnumerable<Account>> GetAll(Expression<Func<Account, bool>>? expression = null);
        Task<Account> GetById(Guid id);
    }
}
