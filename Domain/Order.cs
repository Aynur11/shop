using System;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
