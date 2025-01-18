using MicroServiceProjectOrder.Models;
using MicroServiceProjectOrder.Service;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceProjectOrder.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly OrderService _orderService;

		public OrdersController(OrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public IActionResult GetAll() => Ok(_orderService.GetAll());

		[HttpPost]
		public async Task<IActionResult> Add(Order order)
		{
			var result = await _orderService.AddAsync(order);
			if (result)
				return CreatedAtAction(nameof(GetAll), null);
			else
				return BadRequest();
		}
	}
}
