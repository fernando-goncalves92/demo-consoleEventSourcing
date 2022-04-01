using demo_consoleEventSourcing.Domain;
using demo_consoleEventSourcing.Exceptions;
using System.Collections.Generic;

namespace demo_consoleEventSourcing.Infraestructure
{
    public class ProductRepository
    {
        private readonly Dictionary<string, Product> _inMemoryProducts = new();

        public Product GetProduct(string code)
        {
            return _inMemoryProducts[code];
        }

        public void CreateProduct(Product product)
        {
            string productCode = product.Code;

            if (_inMemoryProducts.ContainsKey(productCode))
            {
                throw new ProductAlreadyExistsException("This product already exists!");
            }

            _inMemoryProducts.Add(productCode, product);
        }

        public void UpdateProduct(Product product)
        {
            string productCode = product.Code;

            if (!_inMemoryProducts.ContainsKey(productCode))
            {
                throw new ProductDoesNotExistsException("This product code does not exists!");
            }

            _inMemoryProducts[product.Code] = product;
        }
    }
}
