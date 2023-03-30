using alsatcomAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Repositories
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
        public Task<Order> GetByIdWithInclude(string id, bool tracking = true);
    }

    public interface IOrderWriteRepository : IWriteRepository<Order>
    {
    }
}
