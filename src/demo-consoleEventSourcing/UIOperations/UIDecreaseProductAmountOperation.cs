using demo_consoleEventSourcing.Exceptions;
using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;
using System;

namespace demo_consoleEventSourcing.Operations
{
    public class UIDecreaseProductAmountOperation : IUIOperation
    {
        private readonly ProductService _productService;

        public UIDecreaseProductAmountOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Decrease Product Amount").Centered());
                Console.WriteLine();
                Console.WriteLine();

                string code = AnsiConsole.Ask<string>("Inform the [green]product code:[/] ");
                Console.WriteLine();
                int amount = AnsiConsole.Ask<int>($"Inform the amount you want to [red]decrease[/]: ");

                _productService.DecreaseAmount(code, amount);

                Console.WriteLine();

                AnsiConsole.Write(new Markup($"[green]Product amount has been decreased successfully![/]"));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine();

                AnsiConsole.Write(new Markup($"[red]{e.Message}[/]"));
            }
            catch (ProductDoesNotExistsException e)
            {
                Console.WriteLine();

                AnsiConsole.Write(new Markup($"[red]{e.Message}[/]"));
            }
            catch (Exception e)
            {
                Console.WriteLine();

                AnsiConsole.WriteException(e);
            }

            Console.WriteLine();
            Console.WriteLine();
            AnsiConsole.Write(new Markup("[yellow]Press any key to go back to main menu...[/]"));

            Console.ReadKey();
        }
    }
}
