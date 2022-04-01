using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;
using Spectre.Console;
using System;

namespace demo_consoleEventSourcing.Operations
{
    public class UIRegisterProductOperation : IUIOperation
    {
        private ProductService _productService;

        public UIRegisterProductOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Register Product").Centered());

            // Informe o código do produto
            // Informe a descrição do produto
            // Mensagem de sucesso
            // Mensagem para apertar qualquer tecla para voltar ao menu principal

            Console.ReadKey();
        }
    }
}
