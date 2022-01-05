using System;
using System.Collections.Generic;
using Domain;

namespace Application.DTO.UpdateEntity
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        //public List<Product> Products { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
