using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class RegisterProductOperation : IOperation
    {
        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Register Product").Centered());
        }
    }
}
