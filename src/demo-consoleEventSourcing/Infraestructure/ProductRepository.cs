using System.Collections.Generic;
using demo_consoleEventSourcing.Domain;

namespace demo_consoleEventSourcing.Infraestructure
{
    public class ProductRepository
    {
        private readonly Dictionary<string, Product> _inMemoryProducts = new();

        public Product GetProduct(string code)
        {
            return _inMemoryProducts.ContainsKey(code) ? _inMemoryProducts[code] : null;
        }

        public void CreateProduct(Product product)
        {
            _inMemoryProducts.Add(product.Code, product);
        }

        public void UpdateProduct(Product product)
        {
            _inMemoryProducts[product.Code] = product;
        }
    }
}
