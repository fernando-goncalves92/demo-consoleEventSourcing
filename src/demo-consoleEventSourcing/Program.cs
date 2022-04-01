﻿using System;
using Spectre.Console;
using System.Threading.Tasks;
using demo_consoleEventSourcing.Operations;

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

        public static async Task Main()
        {
            BuildMenu();
        }

        private static void BuildMenu()
        {
            AnsiConsole.Write(new FigletText("Welcome to Event Sourcing demo").Centered().Color(Color.Violet));

            Console.WriteLine();
            Console.WriteLine();

            string option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[bold yellow]Choose one operation[/]")
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
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
                })).Substring(0, 1);

            var operationContext = new OperationContext();

            switch (option)
            {
                case RegisterProduct:
                    {
                        operationContext.SetOperation(new RegisterProductOperation());

                        break;
                    }
                case SeeProducts:
                    {
                        operationContext.SetOperation(new SeeProductsOperation());

                        break;
                    }
                case IncreaseProduct:
                    {
                        operationContext.SetOperation(new IncreaseProductAmountOperation());

                        break;
                    }
                case DecreaseProduct:
                    {
                        operationContext.SetOperation(new DecreaseProductAmountOperation());

                        break;
                    }
                case AdjustProductAmount:
                    {
                        operationContext.SetOperation(new AdjustProductAmountOperation());

                        break;
                    }
                case GetProductAmount:
                    {
                        operationContext.SetOperation(new GetProductAmountOperation());

                        break;
                    }
                case GetProductEvents:
                    {
                        operationContext.SetOperation(new GetProductEventOperation());

                        break;
                    }
                case Exit:
                    {
                        Environment.Exit(0);

                        break;
                    }
            }

            operationContext.ExecuteOperation();

            Console.ReadKey();
        }
    }
}