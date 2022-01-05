using Application.DTO;
using Application.DTO.UpdateEntity;
using Application.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : BaseApiController
    {
        [HttpPost("AddOrder")]
        public async Task AddOrder(OrderDto order)
        {
            await Mediator.Send(new CreateOrder.Command(order));
        }

        [HttpDelete("DeleteOrder")]
        public async Task DeleteOrder(int id)
        {
            await Mediator.Send(new DeleteOrder.Command(id));
        }

        [HttpGet("GetAllOrder")]
        public async Task<List<OrderDto>> GetAllOrder()
        {
            return await Mediator.Send(new GetAllOrders.Query());
        }

        [HttpGet("GetOrder/{id:int}")]
        public async Task<OrderDto> GetOrder(int id)
        {
            return await Mediator.Send(new GetOrder.Query(id));
        }

        [HttpPut("UpdateOrder")]
        public async Task UpdateOrder(UpdateOrderDto section)
        {
            await Mediator.Send(new UpdateOrder.Command(section));
        }
    }
}
