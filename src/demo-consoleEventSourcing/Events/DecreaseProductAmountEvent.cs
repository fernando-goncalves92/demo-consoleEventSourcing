using demo_consoleEventSourcing.Interfaces;
using System;

namespace demo_consoleEventSourcing.Events
{
    public record DecreaseProductAmountEvent(string Code, int Amount, DateTime DecreasedAt) : IEvent 
    {
        public override string ToString() => $"Amount decreased by {Amount} at {DecreasedAt:dd/MM HH:mm}";
    }
}
