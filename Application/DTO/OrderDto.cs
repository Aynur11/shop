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
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
