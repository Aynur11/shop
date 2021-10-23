using Domain;
using System;

namespace Application.DTO
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class OrderDto
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
