﻿using System;
using System.Collections.Generic;

namespace SimpleCQRS.ReadModel
{
    internal class FakeDatabase
    {
        public static Dictionary<Guid, InventoryItemDetailsDto> details = new Dictionary<Guid, InventoryItemDetailsDto>();
        public static List<InventoryItemListDto> list = new List<InventoryItemListDto>();
    }
}
