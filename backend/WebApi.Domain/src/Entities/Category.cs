using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.src.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}