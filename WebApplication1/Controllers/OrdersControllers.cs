using BeerSupplyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeerSupplyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IStockService _stockService;

        public OrdersController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        public IActionResult CreateOrder()
        {
            var order = _stockService.CreateOrder();
            return Ok(order);
        }

        [HttpPost("{orderId}/add-item")]
        public IActionResult AddOrderItem(int orderId, int kegId, int quantity)
        {
            _stockService.AddOrderItem(orderId, kegId, quantity);
            return Ok();
        }

        [HttpDelete("{orderId}/remove-item/{orderItemId}")]
        public IActionResult RemoveOrderItem(int orderId, int orderItemId)
        {
            _stockService.RemoveOrderItem(orderId, orderItemId);
            return Ok();
        }

        [HttpPost("{orderId}/finalize")]
        public IActionResult FinalizeOrder(int orderId)
        {
            _stockService.FinalizeOrder(orderId);
            return Ok();
        }
    }
}
