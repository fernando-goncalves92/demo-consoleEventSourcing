using demo_consoleEventSourcing.Interfaces;
using System;

namespace demo_consoleEventSourcing.Events
{
    public record DecreaseProductAmountEvent(string Code, int Amount, DateTime DecreaseadAt) : IEvent { }
}
