using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class UIGetProductAmountOperation : IUIOperation
    {
        private readonly ProductService _productService;

        public UIGetProductAmountOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Get Product Amount").Centered());
        }
     }
}
