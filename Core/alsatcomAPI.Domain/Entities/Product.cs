using alsatcomAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid DealerId { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public float DiscountedPrice { get; set; }
        public string Description { get; set; }
        public Dealer Dealer { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
