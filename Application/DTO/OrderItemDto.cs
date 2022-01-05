using CSharpFunctionalExtensions;

namespace Application.DTO
{
    public class OrderItemDto : Entity<int>
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
