using Spectre.Console;
using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using System;
using demo_consoleEventSourcing.Exceptions;

namespace demo_consoleEventSourcing.Operations
{
    public class UIAdjustProductAmountOperation : IUIOperation
    {
        private readonly ProductService _productService;

        public UIAdjustProductAmountOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Adjust Product Amount").Centered());
                Console.WriteLine();
                Console.WriteLine();

                string code = AnsiConsole.Ask<string>("Inform the [green]product code:[/] ");
                Console.WriteLine();
                int amount = AnsiConsole.Ask<int>($"Inform the [green]new[/] amount for product {code}: ");
                Console.WriteLine();
                string reasonAdjust = AnsiConsole.Ask<string>($"Inform the [yellow]reason[/] for this adjust amount: ");

                _productService.AdjustAmount(code, amount, reasonAdjust);

                Console.WriteLine();

                AnsiConsole.Write(new Markup($"[green]Product amount has been adjusted successfully![/]"));
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
