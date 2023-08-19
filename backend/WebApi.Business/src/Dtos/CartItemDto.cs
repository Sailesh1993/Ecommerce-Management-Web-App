using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;

namespace WebApi.Business.src.Dtos
{
    public class CartItemReadDto
    {
        public int Quantity { get; set; }
    }

    public class CartItemCreateDto
    {
        public int Quantity { get; set; }
    }

    public class CartItemUpdateDto
    {
        public int Quantity { get; set; }
    }
}