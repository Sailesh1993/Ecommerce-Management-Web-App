using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;

namespace WebApi.Business.src.Dtos
{
    public class OrderProductReadDto
    {
        public int Quantity { get; set; }
    }

    public class OrderProductCreateDto
    {
        public int Quantity { get; set; }
    }

    public class OrderProductUpdateDto
    {
        public int Quantity { get; set; }
    }
}