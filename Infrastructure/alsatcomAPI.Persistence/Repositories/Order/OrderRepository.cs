using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using alsatcomAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(AlsatcomDbContext context) : base(context)
        {
        }
    }

    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(AlsatcomDbContext context) : base(context)
        {
        }
    }
}
