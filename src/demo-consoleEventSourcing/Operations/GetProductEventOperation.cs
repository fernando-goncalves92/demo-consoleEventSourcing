using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class GetProductEventOperation : IOperation
    {
        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Get Product Events").Centered());
        }
     }
}
