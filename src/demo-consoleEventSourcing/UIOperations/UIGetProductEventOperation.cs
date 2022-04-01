using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class UIGetProductEventOperation : IUIOperation
    {
        private ProductService _productService;

        public UIGetProductEventOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Get Product Events").Centered());
        }
     }
}
