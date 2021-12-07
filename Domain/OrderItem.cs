using CSharpFunctionalExtensions;

namespace Domain
{
    /// <summary>
    /// Информация о товаре в заказе.
    /// </summary>
    public class OrderItem : Entity<int>
    {
        public ProductQuantity Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
