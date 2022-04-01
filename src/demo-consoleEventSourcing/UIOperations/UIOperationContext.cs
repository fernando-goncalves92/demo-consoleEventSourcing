using demo_consoleEventSourcing.Interfaces;
using Spectre.Console;
using System;

namespace demo_consoleEventSourcing.Operations
{
    public class UIOperationContext
    {
        private IUIOperation _operation;
        
        public void ExecuteOperation()
        {
            if (_operation is null)
            {
                AnsiConsole.Write(new Markup("[red]No operation has been set![/]"));

                return;
            }

            Console.Clear();

            _operation.Execute();
        }

        public void SetOperation(IUIOperation operation)
        {
            _operation = operation;
        }
    }
}
