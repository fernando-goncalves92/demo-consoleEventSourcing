using demo_consoleEventSourcing.Interfaces;
using System;

namespace demo_consoleEventSourcing.Events
{
    public record RegisterProductEvent(string Code, string Description, DateTime RegisterAt) : IEvent 
    {
        public override string ToString() => $"Registered at {RegisterAt:dd/MM HH:mm}";        
    }
}
