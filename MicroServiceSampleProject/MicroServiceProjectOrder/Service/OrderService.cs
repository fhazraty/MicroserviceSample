using MicroServiceProjectOrder.Models;

namespace MicroServiceProjectOrder.Service
{
	public class OrderService
	{
		private readonly HttpClient _httpClient;
		private readonly List<Order> _orders = new();

		public OrderService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public IEnumerable<Order> GetAll() => _orders;

		public async Task<bool> AddAsync(Order order)
		{
			// درخواست به ProductService
			var product = await _httpClient.GetFromJsonAsync<Product>($"http://localhost:5001/api/products/{order.ProductId}");

			if (product == null)
				return false; // محصول پیدا نشد

			// محاسبه موجودی باقی‌مانده
			var existingOrdersQuantity = _orders.Where(o => o.ProductId == order.ProductId).Sum(o => o.Quantity);
			var remainingStock = product.Stock - existingOrdersQuantity;

			if (remainingStock < order.Quantity)
				return false; // موجودی کافی نیست

			// محاسبه قیمت کل
			order.TotalPrice = product.Price * order.Quantity;
			_orders.Add(order);
			return true;
		}
	}

	public record Product(int Id, string Name, decimal Price, int Stock);
}
