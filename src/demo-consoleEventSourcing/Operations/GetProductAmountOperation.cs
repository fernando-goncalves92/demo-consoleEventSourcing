using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class GetProductAmountOperation : IOperation
    {
        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Get Product Amount").Centered());
        }
     }
}
