using Application.DTO;
using Application.DTO.UpdateEntity;
using Application.OrderItems;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemsController : BaseApiController
    {
        [HttpPost("AddOrderItem")]
        public async Task AddOrderItem(OrderItemDto orderItem)
        {
            await Mediator.Send(new CreateOrderItem.Command(orderItem));
        }

        [HttpDelete("DeleteOrderItem")]
        public async Task DeleteOrderItem(int id)
        {
            await Mediator.Send(new DeleteOrderItem.Command(id));
        }

        [HttpGet("GetAllOrderItem")]
        public async Task<List<OrderItemDto>> GetAllOrderItem()
        {
            return await Mediator.Send(new GetAllOrderItems.Query());
        }

        [HttpGet("GetOrderItem/{id:int}")]
        public async Task<OrderItemDto> GetOrderItem(int id)
        {
            return await Mediator.Send(new GetOrderItem.Query(id));
        }

        [HttpPut("UpdateOrderItem")]
        public async Task UpdateOrderItem(UpdateOrderItemDto section)
        {
            await Mediator.Send(new UpdateOrderItem.Command(section));
        }
    }
}
