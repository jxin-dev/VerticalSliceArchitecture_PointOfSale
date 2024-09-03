﻿namespace Web.Api.Common
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public List<IDomainEvent> DomainEvents => _domainEvents;

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void Raise(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

    }
}
