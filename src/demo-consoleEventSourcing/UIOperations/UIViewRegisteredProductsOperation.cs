using demo_consoleEventSourcing.Infraestructure;
using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;
using System;

namespace demo_consoleEventSourcing.Operations
{
    public class UIViewRegisteredProductsOperation : IUIOperation
    {
        private readonly ProductService _productService;

        public UIViewRegisteredProductsOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Registered Products").Centered());
                Console.WriteLine();
                Console.WriteLine();

                int amountToSee = AnsiConsole.Ask<int>("Inform how many products you want to see in the table ([yellow]0 to see all of them[/]): ");
                Console.WriteLine();
                var products = _productService.GetProducts(amountToSee);

                var table = new Table();
                table.AddColumn("[yellow]Code[/]");
                table.AddColumn("[yellow]Description[/]");
                table.AddColumn(new TableColumn("[yellow]Amount[/]").RightAligned());
                table.AddColumn(new TableColumn("[yellow]Registered At[/]").RightAligned());
                table.AddColumn(new TableColumn("[yellow]Updated At[/]").RightAligned());
                table.Border(TableBorder.Ascii);
                table.BorderColor(Color.Blue3);

                foreach (var product in products)
                {
                    table.AddRow(product.Code, 
                        product.Description, 
                        product.Amount.ToString(),
                        product.RegisterAt.ToString("yyyy-MM-dd HH:mm:ss"),
                        product.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
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
