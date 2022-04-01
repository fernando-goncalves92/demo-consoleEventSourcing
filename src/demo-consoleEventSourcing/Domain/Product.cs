using demo_consoleEventSourcing.Events;
using demo_consoleEventSourcing.Interfaces;
using System;
using System.Collections.Generic;

namespace demo_consoleEventSourcing.Domain
{
    public record Product
    {
        public string Code { get; private set; }
        public string Description { get; private set; }
        public int Amount { get; private set; }
        public DateTime RegisterAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private List<IEvent> _events = new();

        public Product(string code, string description)
        {
            Code = code;
            Description = description;
            RegisterAt = DateTime.Now;
            UpdatedAt = RegisterAt;
            Amount = 0;

            AddEvent(new RegisterProductEvent(Code, Description, RegisterAt));
        }

        public void IncreaseAmount(int amount)
        {
            AddEvent(new IncreaseProductAmountEvent(Code, amount, DateTime.Now));
        }

        public void DecreaseAmount(int amount)
        {
            AddEvent(new DecreaseProductAmountEvent(Code, amount, DateTime.Now));
        }

        public void AdjustAmount(int amount, string reasonAdjust)
        {
            AddEvent(new AdjustProductAmountEvent(Code, amount, reasonAdjust, DateTime.Now));
        }

        public void AddEvent(IEvent @event)
        {
            switch (@event)
            {
                case RegisterProductEvent: break;
                case IncreaseProductAmountEvent increase:
                    {
                        Apply(increase);

                        break;
                    }
                case DecreaseProductAmountEvent decrease:
                    {
                        Apply(decrease);

                        break;
                    }
                case AdjustProductAmountEvent adjust:
                    {
                        Apply(adjust);

                        break;
                    }
            }

            _events.Add(@event);
        }

        public List<IEvent> GetEvents()
        {
            return _events;
        }

        private void Apply(IncreaseProductAmountEvent increase)
        {
            Amount += increase.Amount;
            UpdatedAt = DateTime.Now;
        }

        private void Apply(DecreaseProductAmountEvent decrease)
        {
            Amount -= decrease.Amount;
            UpdatedAt = DateTime.Now;
        }

        private void Apply(AdjustProductAmountEvent adjust)
        {
            Amount = adjust.Amount;
            UpdatedAt = DateTime.Now;
        }        
    }
}
