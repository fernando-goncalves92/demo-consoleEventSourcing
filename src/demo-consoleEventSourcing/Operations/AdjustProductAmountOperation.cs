using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class AdjustProductAmountOperation : IOperation
    {
        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Adjust Product Amount").Centered());
        }
     }
}
