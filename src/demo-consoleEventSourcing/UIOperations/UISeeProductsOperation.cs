using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;

namespace demo_consoleEventSourcing.Operations
{
    public class UISeeProductsOperation : IUIOperation
    {
        private ProductService _productService;

        public UISeeProductsOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            AnsiConsole.Write(new FigletText("See Products").Centered());

            // Informe o código do produto
            // Lista os produtos em formato de tabela
            // Mensagem para apertar qualquer tecla para voltar ao menu principal
        }
    }
}
