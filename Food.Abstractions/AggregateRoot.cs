using System;
using System.Collections.Generic;
using ReflectionMagic;

namespace Food.Abstractions
{
    public abstract class AggregateRoot : IEntity
    {
        public Guid Id { get; set; }
        public int Version { get; set; } = -1;
        private readonly List<IDomainEvent> _uncommitedChanges = new();
        
        public void MarkChangesAsCommitted() 
        {
            _uncommitedChanges.Clear();
        }

        public IList<IDomainEvent> GetUncommittedEvents() => _uncommitedChanges;
        
        public void LoadsFromHistory(IEnumerable<IDomainEvent> history) 
        {
            foreach (var e in history) ApplyChange(e, false);
        }
        
        protected void ApplyChange(IDomainEvent domainEvent, long? version = default) 
        {
            ApplyChange(domainEvent, true, version);
        }
        
        public void ApplyChange(dynamic domainEvent, bool isNew, long? version = default)
        {
            var @event = domainEvent.WithAggregate(Id, version ?? Version + 1);
            this.AsDynamic().Apply(@event);
            if (isNew)
                _uncommitedChanges.Add(@event);
        }
    }
}