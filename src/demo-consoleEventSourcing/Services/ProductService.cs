using demo_consoleEventSourcing.Domain;
using demo_consoleEventSourcing.Exceptions;
using demo_consoleEventSourcing.Infraestructure;
using demo_consoleEventSourcing.Interfaces;
using System;
using System.Collections.Generic;

namespace demo_consoleEventSourcing.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(string code)
        {
            return _productRepository.GetProduct(code);
        }

        public List<Product> GetProducts(int limit)
        {
            return _productRepository.GetProducts(limit);
        }

        public int GetProductAmount(string code)
        {
            var product = GetProduct(code);

            ThrowProductDoesNotExistsExceptionIfNull(product);

            return product.Amount;
        }

        public void CreateProduct(string code, string description)
        {
            var product = GetProduct(code);

            if (product != null)
            {
                throw new ProductAlreadyExistsException($"A product with code {code} already exists!");
            }

            _productRepository.CreateProduct(new Product(code, description));
        }

        public void IncreaseAmount(string code, int amount)
        {
            if (amount <= 0)
            { 
                throw new InvalidOperationException("It's not possible to increase a negative amount!");
            }

            var product = GetProduct(code);

            ThrowProductDoesNotExistsExceptionIfNull(product);

            product.IncreaseAmount(amount);

            _productRepository.UpdateProduct(product);
        }

        public void DecreaseAmount(string code, int amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("It's not possible to decrease a negative amount!");
            }

            var product = GetProduct(code);

            ThrowProductDoesNotExistsExceptionIfNull(product);

            product.DecreaseAmount(amount);

            _productRepository.UpdateProduct(product);
        }

        public void AdjustAmount(string code, int amount, string reasonAdjust)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("It's not possible to decrease a negative amount!");
            }

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
