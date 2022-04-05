using demo_consoleEventSourcing.Exceptions;
using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;
using System;

namespace demo_consoleEventSourcing.Operations
{
    public class UIViewProductAmountOperation : IUIOperation
    {
        private readonly ProductService _productService;

        public UIViewProductAmountOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Product Amount").Centered());
                Console.WriteLine();
                Console.WriteLine();

                string code = AnsiConsole.Ask<string>("Inform the [green]product code[/] you want to get the current amount: ");
                Console.WriteLine();
                int amount = _productService.GetProductAmount(code);

                AnsiConsole.Write(new Markup($"This is the [yellow]current[/] amount for the product [green]{code}[/]: {amount}"));                
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
