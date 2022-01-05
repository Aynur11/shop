using Domain;
using System;
using System.Collections.Generic;

namespace Application.DTO
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class OrderDto
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        //public List<Product> Products { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
