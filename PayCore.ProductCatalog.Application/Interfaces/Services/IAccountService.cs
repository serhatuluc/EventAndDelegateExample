using PayCore.ProductCatalog.Application.Dto_Validator.Account.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountViewDto>> GetAll();
        Task<AccountViewDto> GetById(Guid id);
        Task Insert(AccountUpsertDto dto);
        Task Remove(Guid id);
        Task Update(Guid id, AccountUpsertDto dto);
    }
}
