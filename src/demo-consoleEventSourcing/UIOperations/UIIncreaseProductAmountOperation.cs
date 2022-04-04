using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;

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
            AnsiConsole.Write(new FigletText("Increase Product Amount").Centered());

            // Informe o código do produto
            // Informe a quantidade do produto
            // Mensagem de sucesso
            // Mensagem para apertar qualquer tecla para voltar ao menu principal
        }
    }
}
