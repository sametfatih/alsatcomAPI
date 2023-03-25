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
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(AlsatcomDbContext context) : base(context)
        {
        }
    }

    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(AlsatcomDbContext context) : base(context)
        {
        }
    }
}
