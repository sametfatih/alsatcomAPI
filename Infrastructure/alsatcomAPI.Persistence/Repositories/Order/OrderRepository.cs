using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using alsatcomAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        private readonly AlsatcomDbContext _context;

        public OrderReadRepository(AlsatcomDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdWithInclude(string id, bool tracking = true)
        {
            var query = _context.Set<Order>().AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.Include(o => o.Customer).Include(o => o.Products).FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));
        }
    }

    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(AlsatcomDbContext context) : base(context)
        {
        }
    }
}
