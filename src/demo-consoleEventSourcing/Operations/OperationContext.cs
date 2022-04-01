using System;

namespace demo_consoleEventSourcing.Operations
{
    public class OperationContext
    {
        private IOperation _operation;
        
        public void ExecuteOperation()
        {
            Console.Clear();

            _operation.Execute();
        }

        public void SetOperation(IOperation operation)
        {
            _operation = operation;
        }
    }
}
