using System;
using System.Collections.Generic;

namespace Application.DTO.UpdateEntity
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public List<UpdateOrderItemDto> Items { get; set; } = new();
        public DateTime OrderTime { get; set; }
    }
}
