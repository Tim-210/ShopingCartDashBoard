using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class ProductIndexVM
    {
       
        public int ProductId { get; set; }
        
        public int CategoryId { get; set; }

        public string Name { get; set; }
   
        public decimal Price { get; set; }
    
        public string Path { get; set; }

        public string CategoryName { get; set; }

        public virtual Category Category { get; set; }
    }
}
