using System;
using System.Collections.Generic;

namespace Application.DTO
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class OrderDto
    {
        public List<OrderItemDto> Items { get; set; } = new();
        public DateTime OrderTime { get; set; }
    }
}
