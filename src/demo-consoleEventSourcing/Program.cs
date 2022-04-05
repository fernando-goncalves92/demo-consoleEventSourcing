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
        private const string SeeProducts = "2";
        private const string IncreaseProduct = "3";
        private const string DecreaseProduct = "4";
        private const string AdjustProductAmount = "5";
        private const string GetProductAmount = "6";
        private const string GetProductEvents = "7";
        private const string Exit = "8";

        private static UIOperationContext _operationContext;        
        private static UIRegisterProductOperation _registerOperation;
        private static UISeeProductsOperation _seeProductsOperation;
        private static UIIncreaseProductAmountOperation _increaseProductAmountOperation;
        private static UIDecreaseProductAmountOperation _decreaseProductAmountOperation;
        private static UIAdjustProductAmountOperation _adjustProductAmountOperation;
        private static UIGetProductAmountOperation _getProductAmountOperation;
        private static UIGetProductEventOperation _getProductEventOperation;

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
            _seeProductsOperation = new UISeeProductsOperation(_productService);
            _increaseProductAmountOperation = new UIIncreaseProductAmountOperation(_productService);
            _decreaseProductAmountOperation = new UIDecreaseProductAmountOperation(_productService);
            _adjustProductAmountOperation = new UIAdjustProductAmountOperation(_productService);
            _getProductAmountOperation = new UIGetProductAmountOperation(_productService);
            _getProductEventOperation = new UIGetProductEventOperation(_productService);
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
                        "2 - See registered products",
                        "3 - Increase product amount",
                        "4 - Decrease product amount",
                        "5 - Adjust product amount",
                        "6 - Get product amount",
                        "7 - Get product events",
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
                    case SeeProducts:
                        {
                            _operationContext.SetOperation(_seeProductsOperation);

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
                    case GetProductAmount:
                        {
                            _operationContext.SetOperation(_getProductAmountOperation);

                            break;
                        }
                    case GetProductEvents:
                        {
                            _operationContext.SetOperation(_getProductEventOperation);

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
