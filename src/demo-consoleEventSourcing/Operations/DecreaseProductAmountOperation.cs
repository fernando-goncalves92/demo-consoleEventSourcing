using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class DecreaseProductAmountOperation : IOperation
    {
        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Decrease Product Amount").Centered());
        }
     }
}
