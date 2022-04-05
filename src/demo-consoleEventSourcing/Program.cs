using System;
using Spectre.Console;
using System.Threading.Tasks;
using demo_consoleEventSourcing.Operations;
using demo_consoleEventSourcing.Services;
using demo_consoleEventSourcing.Infraestructure;

namespace demo_consoleEventSourcing
{
    public class Program
    {
        private const string RegisterProduct = "1";
        private const string IncreaseProduct = "2";
        private const string DecreaseProduct = "3";
        private const string AdjustProductAmount = "4";
        private const string ViewRegisteredProducts = "5";
        private const string ViewProductAmount = "6";
        private const string ViewProductEvents = "7";
        private const string Exit = "8";

        private static UIOperationContext _operationContext;
        private static UIRegisterProductOperation _registerOperation;
        private static UIIncreaseProductAmountOperation _increaseProductAmountOperation;
        private static UIDecreaseProductAmountOperation _decreaseProductAmountOperation;
        private static UIAdjustProductAmountOperation _adjustProductAmountOperation;
        private static UIViewRegisteredProductsOperation _viewRegisteredProductsOperation;
        private static UIViewProductAmountOperation _viewProductAmountOperation;
        private static UIViewProductEventOperation _viewProductEventOperation;

        public static void Main()
        {
            BuildUIOperations();

            BuildAndRunMainMenu();
        }

        private static void BuildUIOperations()
        {
            var _productService = new ProductService(new ProductRepository());

            _operationContext = new UIOperationContext();
            _registerOperation = new UIRegisterProductOperation(_productService);
            _increaseProductAmountOperation = new UIIncreaseProductAmountOperation(_productService);
            _decreaseProductAmountOperation = new UIDecreaseProductAmountOperation(_productService);
            _adjustProductAmountOperation = new UIAdjustProductAmountOperation(_productService);
            _viewRegisteredProductsOperation = new UIViewRegisteredProductsOperation(_productService);
            _viewProductAmountOperation = new UIViewProductAmountOperation(_productService);
            _viewProductEventOperation = new UIViewProductEventOperation(_productService);
        }

        private static void BuildAndRunMainMenu()
        {
            while (true)
            {
                Console.Clear();

                AnsiConsole.Write(new FigletText("Welcome to Event Sourcing demo").Centered().Color(Color.Violet));

                Console.WriteLine();
                Console.WriteLine();

                string option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("[bold yellow]Choose one operation[/]")
                    .AddChoices(new[]
                    {
                        "1 - Register product",
                        "2 - Increase product amount",
                        "3 - Decrease product amount",
                        "4 - Adjust product amount",
                        "5 - View registered products",
                        "6 - View product amount",
                        "7 - View product events",
                        "8 - Exit"
                    }))
                    .Substring(0, 1);

                switch (option)
                {
                    case RegisterProduct:
                        {
                            _operationContext.SetOperation(_registerOperation);

                            break;
                        }
                    case IncreaseProduct:
                        {
                            _operationContext.SetOperation(_increaseProductAmountOperation);

                            break;
                        }
                    case DecreaseProduct:
                        {
                            _operationContext.SetOperation(_decreaseProductAmountOperation);

                            break;
                        }
                    case AdjustProductAmount:
                        {
                            _operationContext.SetOperation(_adjustProductAmountOperation);

                            break;
                        }
                    case ViewRegisteredProducts:
                        {
                            _operationContext.SetOperation(_viewRegisteredProductsOperation);

                            break;
                        }
                    case ViewProductAmount:
                        {
                            _operationContext.SetOperation(_viewProductAmountOperation);

                            break;
                        }
                    case ViewProductEvents:
                        {
                            _operationContext.SetOperation(_viewProductEventOperation);

                            break;
                        }
                    case Exit:
                        {
                            Environment.Exit(0);

                            break;
                        }
                }

                _operationContext.ExecuteOperation();
            }
        }
    }
}
