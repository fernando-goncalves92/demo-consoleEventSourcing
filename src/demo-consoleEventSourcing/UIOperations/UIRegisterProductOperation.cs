using demo_consoleEventSourcing.Exceptions;
using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;
using System;

namespace demo_consoleEventSourcing.Operations
{
    public class UIRegisterProductOperation : IUIOperation
    {
        private readonly ProductService _productService;

        public UIRegisterProductOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Register Product").Centered());
                Console.WriteLine();
                Console.WriteLine();
                
                string code = AnsiConsole.Ask<string>("Inform the [green]product code:[/] ");
                Console.WriteLine();
                string description = AnsiConsole.Ask<string>($"Inform the description for product code [green]{code}[/]: ");
                
                _productService.CreateProduct(code, description);
                
                Console.WriteLine();
                
                AnsiConsole.Write(new Markup($"[green]Product {code} has been registered successfully![/]"));
            }
            catch (ProductAlreadyExistsException e)
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
