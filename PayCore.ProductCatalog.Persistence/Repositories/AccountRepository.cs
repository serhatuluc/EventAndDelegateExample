using NHibernate;
using NHibernate.Linq;
using PayCore.ProductCatalog.Application.Interfaces.Log;
using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using PayCore.ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ILoggerManager Logger;
        private readonly ISession session;
        private ITransaction transaction;

        public AccountRepository(ISession session, ILoggerManager Logger) 
        {
            this.session = session;
            this.Logger = Logger;
        }

        public async Task Create(Account entity)
        {
            try
            {
                transaction = session.BeginTransaction();
                await session.SaveAsync(entity);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Logger.LogError(ex, "Insert Error");
            }
            finally
            {
                session.Dispose();
            };
        }

        public async Task Delete(Account entity)
        {
            try
            {
                transaction = session.BeginTransaction();
                await session.DeleteAsync(entity);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {

                Logger.LogError(ex, "Delete Error");
            }
            finally
            {
                session.Dispose();
            };
        }

        public async Task<IEnumerable<Account>> GetAll(Expression<Func<Account, bool>> expression = null)
        {
            var listOfcontainers = await session.Query<Account>().ToListAsync();
            return listOfcontainers;
        }

        public async Task<Account> GetById(Guid id)
        {
            return await session.Query<Account>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(Account entity)
        {
            try
            {
                transaction = session.BeginTransaction();
                await session.UpdateAsync(entity);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Logger.LogError(ex, "Update Error");
            }
            finally
            {
                session.Dispose();
            }
        }
    }
}

