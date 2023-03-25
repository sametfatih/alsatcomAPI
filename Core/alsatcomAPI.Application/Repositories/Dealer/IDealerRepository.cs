using alsatcomAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Repositories
{
    public interface IDealerReadRepository : IReadRepository<Dealer>
    {
    }

    public interface IDealerWriteRepository : IWriteRepository<Dealer>
    {
    }
}
