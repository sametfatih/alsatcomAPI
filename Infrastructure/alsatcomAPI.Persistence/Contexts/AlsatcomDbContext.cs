using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Persistence.Contexts
{
    public class AlsatcomDbContext : DbContext
    {
        public AlsatcomDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
