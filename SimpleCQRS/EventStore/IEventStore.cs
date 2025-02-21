﻿using SimpleCQRS.Domain;
using System;
using System.Collections.Generic;

namespace SimpleCQRS.EventStore
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
        List<Event> GetEventsForAggregate(Guid aggregateId);
    }
}
