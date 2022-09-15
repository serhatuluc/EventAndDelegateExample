using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionArcExample.Domain
{
    public interface IBaseService<Dto, Entity> 
    {
        Task<IEnumerable<Dto>> GetAll();
        Task<Dto> GetById(int id);
        Task<Dto> Insert(Dto dto);
        Task<Dto> Remove(int id);
        Task<Dto> Update(int id, Dto dto);
    }
}
