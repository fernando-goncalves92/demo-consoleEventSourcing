using demo_consoleEventSourcing.Domain;
using demo_consoleEventSourcing.Exceptions;
using demo_consoleEventSourcing.Infraestructure;

namespace demo_consoleEventSourcing.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public Product GetProduct(string code)
        {
            return _productRepository.GetProduct(code);
        }

        public void CreateProduct(string code, string description)
        {
            _productRepository.CreateProduct(new Product(code, description));
        }

        public void IncreaseAmount(string code, int amount)
        {
            var product = GetProduct(code);

            ThrowProductDoesNotExistsExceptionIfNull(product);

            product.IncreaseAmount(amount);

            _productRepository.UpdateProduct(product);
        }

        public void DecreaseAmount(string code, int amount)
        {
            var product = GetProduct(code);

            ThrowProductDoesNotExistsExceptionIfNull(product);

            product.DecreaseAmount(amount);

            _productRepository.UpdateProduct(product);
        }

        public void AdjustAmount(string code, int amount, string reasonAdjust)
        {
            var product = GetProduct(code);

            ThrowProductDoesNotExistsExceptionIfNull(product);

            product.AdjustAmount(amount, reasonAdjust);

            _productRepository.UpdateProduct(product);
        }

        private void ThrowProductDoesNotExistsExceptionIfNull(Product product)
        {
            if (product is null)
            {
                throw new ProductDoesNotExistsException("This product code does not exists!");
            }
        }
    }
}
