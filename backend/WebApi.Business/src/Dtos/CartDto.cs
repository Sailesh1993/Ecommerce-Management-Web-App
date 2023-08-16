using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Business.src.Dtos
{
    public class CartReadDto
    {
        public Decimal TotalAmount { get; set; }
        
    }

    public class CartCreateDto
    {
        public Decimal TotalAmount { get; set; }
        
    }

    public class CartUpdateDto
    {
        public Decimal TotalAmount { get; set; }
        
    }

    
}