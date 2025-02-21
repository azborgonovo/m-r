﻿using SimpleCQRS.Domain;
using SimpleCQRS.MessageBus;

namespace SimpleCQRS.ReadModel
{
    public class InventoryListView : IHandler<InventoryItemCreated>, IHandler<InventoryItemRenamed>, IHandler<InventoryItemDeactivated>
    {
        public void Handle(InventoryItemCreated message)
        {
            FakeDatabase.list.Add(new InventoryItemListDto(message.Id, message.Name));
        }

        public void Handle(InventoryItemRenamed message)
        {
            var item = FakeDatabase.list.Find(x => x.Id == message.Id);
            item.Name = message.NewName;
        }

        public void Handle(InventoryItemDeactivated message)
        {
            FakeDatabase.list.RemoveAll(x => x.Id == message.Id);
        }
    }
}
