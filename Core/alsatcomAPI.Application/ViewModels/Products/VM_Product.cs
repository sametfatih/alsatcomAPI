using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.ViewModels.Products
{
    public class VM_Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public float DiscountedPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
