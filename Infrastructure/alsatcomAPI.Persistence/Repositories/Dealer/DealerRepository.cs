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
    public class DealerReadRepository : ReadRepository<Dealer>, IDealerReadRepository
    {
        public DealerReadRepository(AlsatcomDbContext context) : base(context)
        {
        }
    }

    public class DealerWriteRepository : WriteRepository<Dealer>, IDealerWriteRepository
    {
        public DealerWriteRepository(AlsatcomDbContext context) : base(context)
        {
        }
    }
}
