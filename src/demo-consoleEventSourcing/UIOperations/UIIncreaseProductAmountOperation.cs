using demo_consoleEventSourcing.Exceptions;
using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;
using System;

namespace demo_consoleEventSourcing.Operations
{
    public class UIIncreaseProductAmountOperation : IUIOperation
    {
        private readonly ProductService _productService;

        public UIIncreaseProductAmountOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Increase Product Amount").Centered());
                Console.WriteLine();
                Console.WriteLine();

                string code = AnsiConsole.Ask<string>("Inform the [green]product code:[/] ");
                Console.WriteLine();
                int amount = AnsiConsole.Ask<int>($"Inform the amount you want to [green]increase[/]: ");

                _productService.IncreaseAmount(code, amount);

                Console.WriteLine();

                AnsiConsole.Write(new Markup($"[green]Product amount has been increased successfully![/]"));
            }
            catch(InvalidOperationException e)
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
