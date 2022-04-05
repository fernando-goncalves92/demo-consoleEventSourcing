using demo_consoleEventSourcing.Interfaces;
using System;

namespace demo_consoleEventSourcing.Events
{
    public record AdjustProductAmountEvent(string Code, int Amount, string ReasonAdjust, DateTime AdjustedAt) : IEvent 
    {
        public override string ToString() => $"Amount adjusted to {Amount} at {AdjustedAt:dd/MM HH:mm} with reason \"{ReasonAdjust}\"";
    }
}
