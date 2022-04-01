using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class SeeProductsOperation : IOperation
    {
        public void Execute()
        {
            AnsiConsole.Write(new FigletText("See Products").Centered());
        }
    }
}
