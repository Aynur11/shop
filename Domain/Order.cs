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
        public DateTime OrderTime { get; set; }
    }
}
