using alsatcomAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.ViewModels.Orders
{
    public class VM_Order
    {
        //public int Id { get; set; } 
        public string CustomerId { get; set; }
        public string Adress { get; set; }
        //public Customer Customer { get; set; }
        //public ICollection<Product> Products { get; set; }
    }
}
