using demo_consoleEventSourcing.Interfaces;
using System;

namespace demo_consoleEventSourcing.Events
{
    public record AdjustProductAmountEvent(string Code, int Amount, string ReasonAdjust, DateTime AdjustedAt) : IEvent 
    {
        public override string ToString() 
            => $"Amount adjusted to [yellow]{Amount}[/] at [yellow]{AdjustedAt:dd/MM HH:mm}[/] with reason [yellow]\"{ReasonAdjust}\"[/]";
    }
}
