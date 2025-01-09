using WebAppSample.Models;

namespace WebAppSample.Services
{
	public class ProductService
	{
		private readonly List<Product> _products = new();

		public ProductService()
		{
			// نمونه داده اولیه
			_products.Add(new Product { Id = 1, Name = "Laptop", Price = 1000, Stock = 10 });
			_products.Add(new Product { Id = 2, Name = "Mouse", Price = 20, Stock = 50 });
		}

		public IEnumerable<Product> GetAll() => _products;

		public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

		public void Add(Product product) => _products.Add(product);

		public void Update(Product product)
		{
			var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
			if (existingProduct != null)
			{
				existingProduct.Name = product.Name;
				existingProduct.Price = product.Price;
				existingProduct.Stock = product.Stock;
			}
		}

		public void Delete(int id)
		{
			var product = _products.FirstOrDefault(p => p.Id == id);
			if (product != null)
				_products.Remove(product);
		}
	}
}
