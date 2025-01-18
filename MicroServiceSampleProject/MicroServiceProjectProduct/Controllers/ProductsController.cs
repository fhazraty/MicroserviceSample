using MicroServiceProjectProduct.Models;
using MicroServiceProjectProduct.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceProjectProduct.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ProductService _productService;

		public ProductsController(ProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_productService.GetAll());
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var product = _productService.GetById(id);
			if (product == null)
				return NotFound();
			return Ok(product);
		}

		[HttpPost]
		public IActionResult Add(Product product)
		{
			_productService.Add(product);
			return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, Product product)
		{
			if (id != product.Id)
				return BadRequest();

			_productService.Update(product);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_productService.Delete(id);
			return NoContent();
		}
	}
}
