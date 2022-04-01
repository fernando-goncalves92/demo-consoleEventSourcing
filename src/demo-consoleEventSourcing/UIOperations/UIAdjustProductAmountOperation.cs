﻿using Spectre.Console;
using demo_consoleEventSourcing.Interfaces;
using demo_consoleEventSourcing.Services;

namespace demo_consoleEventSourcing.Operations
{
    public class UIAdjustProductAmountOperation : IUIOperation
    {
        private ProductService _productService;

        public UIAdjustProductAmountOperation(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            AnsiConsole.Write(new FigletText("Adjust Product Amount").Centered());

            // Informe o código do produto
            // Informe a quantidade do produto
            // Mensagem de sucesso
            // Mensagem para apertar qualquer tecla para voltar ao menu principal
        }
    }
}