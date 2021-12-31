using CQRSWebApp.Data;
using SimpleCQRS.CommandHandlers;
using SimpleCQRS.Commands;
using SimpleCQRS.Domain;
using SimpleCQRS.EventStore;
using SimpleCQRS.MessageBus;
using SimpleCQRS.ReadModel;

var builder = WebApplication.CreateBuilder(args);

var bus = new FakeBus();
var storage = new EventStoreImplementation(bus);
var rep = new EventStoreRepository<InventoryItem>(storage);
var commands = new InventoryCommandHandlers(rep);
bus.RegisterHandler<CheckInItemsToInventory>(commands.Handle);
bus.RegisterHandler<CreateInventoryItem>(commands.Handle);
bus.RegisterHandler<DeactivateInventoryItem>(commands.Handle);
bus.RegisterHandler<RemoveItemsFromInventory>(commands.Handle);
bus.RegisterHandler<RenameInventoryItem>(commands.Handle);
var detail = new InventoryItemDetailView();
bus.RegisterHandler<InventoryItemCreated>(detail.Handle);
bus.RegisterHandler<InventoryItemDeactivated>(detail.Handle);
bus.RegisterHandler<InventoryItemRenamed>(detail.Handle);
bus.RegisterHandler<ItemsCheckedInToInventory>(detail.Handle);
bus.RegisterHandler<ItemsRemovedFromInventory>(detail.Handle);
var list = new InventoryListView();
bus.RegisterHandler<InventoryItemCreated>(list.Handle);
bus.RegisterHandler<InventoryItemRenamed>(list.Handle);
bus.RegisterHandler<InventoryItemDeactivated>(list.Handle);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<FakeBus>(bus);
builder.Services.AddTransient<ReadModelFacade>();
builder.Services.AddTransient<InventoryItemsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
