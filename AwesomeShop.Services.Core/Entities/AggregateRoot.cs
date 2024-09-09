using AwesomeShop.Services.Core.Events;
using System;
using System.Collections.Generic;

namespace AwesomeShop.Services.Core.Entities
{
    public class AggregateRoot : IEntityBase
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();
        public Guid Id { get; protected set; }

        public IEnumerable<IDomainEvent> Events => _events;
        protected void AddEvent(IDomainEvent domainEvent)
        {
            if (_events == null)
                _events = new List<IDomainEvent>();
            _events.Add(domainEvent);
        }
    }
}
