using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;
using System;

namespace demo_consoleEventSourcing.Operations
{
    public class UIViewProductEventOperation : IUIOperation
    {
        private readonly ProductService _productService;

        public UIViewProductEventOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Product Events").Centered());
                Console.WriteLine();
                Console.WriteLine();

                string code = AnsiConsole.Ask<string>("Inform the [green]product code:[/] ");
                Console.WriteLine();
                var product = _productService.GetProduct(code);

                var table = new Table();
                table.AddColumn("[yellow]Event[/]");
                table.Border(TableBorder.Markdown);
                table.BorderColor(Color.Blue3);

                foreach (var @event in product.GetEvents())
                {   
                    table.AddRow($"- {@event}");
                }

                AnsiConsole.Write(table);
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
