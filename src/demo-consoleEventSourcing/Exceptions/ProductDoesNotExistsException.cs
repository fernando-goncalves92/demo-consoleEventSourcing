using System;

namespace demo_consoleEventSourcing.Exceptions
{
    public class ProductDoesNotExistsException : Exception
    {
        public ProductDoesNotExistsException() : base() { }
        public ProductDoesNotExistsException(string message) : base (message) { }
    }
}
