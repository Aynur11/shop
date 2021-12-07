using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order : Entity<int>
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public List<Product> Products { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
