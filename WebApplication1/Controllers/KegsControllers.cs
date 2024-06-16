using BeerSupplyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeerSupplyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KegsController : ControllerBase
    {
        private readonly IStockService _stockService;

        public KegsController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost("{kegId}/update-stock")]
        public IActionResult UpdateStock(int kegId, int quantity)
        {
            _stockService.UpdateStock(kegId, quantity);
            return Ok();
        }

        [HttpGet("reorder")]
        public IActionResult GetKegsToReorder()
        {
            var kegs = _stockService.GetKegsToReorder();
            return Ok(kegs);
        }
    }
}
