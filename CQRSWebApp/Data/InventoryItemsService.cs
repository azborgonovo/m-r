using SimpleCQRS.Commands;
using SimpleCQRS.MessageBus;
using SimpleCQRS.ReadModel;

namespace CQRSWebApp.Data
{
    public class InventoryItemsService
    {
        private readonly FakeBus _bus;
        private readonly ReadModelFacade _readModel;

        public InventoryItemsService(FakeBus fakeBus, ReadModelFacade readModel)
        {
            _bus = fakeBus;
            _readModel = readModel;
        }

        public IEnumerable<InventoryItemListDto> GetInventoryItems()
        {
            return _readModel.GetInventoryItems();
        }

        public InventoryItemDetailsDto GetInventoryItemDetails(Guid id)
        {
            return _readModel.GetInventoryItemDetails(id);
        }

        public void CreateInventoryItem(string name)
        {
            _bus.Send(new CreateInventoryItem(Guid.NewGuid(), name));
        }

        public void ChangeInventoryItemName(Guid id, string name, int version)
        {
            var command = new RenameInventoryItem(id, name, version);
            _bus.Send(command);
        }
        
        public void DeactivateInventoryItem(Guid id, int version)
        {
            _bus.Send(new DeactivateInventoryItem(id, version));
        }

        public void CheckInItemsToInventory(Guid id, int number, int version)
        {
            _bus.Send(new CheckInItemsToInventory(id, number, version));
        }

        public void RemoveItemsFromInventory(Guid id, int number, int version)
        {
            _bus.Send(new RemoveItemsFromInventory(id, number, version));
        }
    }
}