using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.ViewModels.Products
{
    public class VM_Product
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public float DiscountedPrice { get; set; }
        public string Description { get; set; }
    }
}
