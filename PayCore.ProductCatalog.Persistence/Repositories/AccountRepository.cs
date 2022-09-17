using NHibernate;
using NHibernate.Linq;
using PayCore.ProductCatalog.Application.Interfaces.Log;
using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using PayCore.ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly ILoggerManager Logger;
        private readonly ISession session;
        private ITransaction transaction;

        public AccountRepository(ISession session, ILoggerManager Logger) : base(session, Logger)
        {
            this.session = session;
            this.Logger = Logger;
        }
    }
}

