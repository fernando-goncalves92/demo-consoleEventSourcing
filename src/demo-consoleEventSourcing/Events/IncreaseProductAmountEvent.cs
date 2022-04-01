using demo_consoleEventSourcing.Interfaces;
using System;

namespace demo_consoleEventSourcing.Events
{
    public record IncreaseProductAmountEvent(string Code, int Amount, DateTime IncreasedAt) : IEvent { }
}
