using PayCore.ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : BaseEntity
    {
        Task Create(Entity entity);
        Task Update(Entity entity);
        Task Delete(Entity entity);
        Task<IEnumerable<Entity>> GetAll(Expression<Func<Entity, bool>>? expression = null);
        Task<Entity> GetById(int id);

    }
}
