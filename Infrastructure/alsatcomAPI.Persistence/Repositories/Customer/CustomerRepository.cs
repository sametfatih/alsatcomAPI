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
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(AlsatcomDbContext context) : base(context)
        {
        }
    }
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(AlsatcomDbContext context) : base(context)
        {
        }
    }
}
