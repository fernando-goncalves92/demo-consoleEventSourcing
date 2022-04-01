using System;

namespace demo_consoleEventSourcing.Exceptions
{
    public class ProductAlreadyExistsException : Exception
    {
        public ProductAlreadyExistsException() : base () { }
        public ProductAlreadyExistsException(string message) : base(message) { }
    }
}
