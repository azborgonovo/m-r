﻿using System;
using System.Collections.Generic;

namespace SimpleCQRS.ReadModel
{
    public class ReadModelFacade : IReadModelFacade
    {
        public IEnumerable<InventoryItemListDto> GetInventoryItems()
        {
            return FakeDatabase.list;
        }

        public InventoryItemDetailsDto GetInventoryItemDetails(Guid id)
        {
            return FakeDatabase.details[id];
        }
    }
}
