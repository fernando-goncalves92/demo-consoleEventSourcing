using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class IncreaseProductAmountOperation : IOperation
    {
        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Increase Product Amount").Centered());
        }
     }
}
