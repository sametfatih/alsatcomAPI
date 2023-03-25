using alsatcomAPI.Domain.Entities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Domain.Entities
{
    public class Dealer : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string CompanyName { get; set; }
        public int Rating { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
