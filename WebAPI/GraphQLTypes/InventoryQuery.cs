using GraphQL;
using GraphQL.Types;

public class InventoryQuery : ObjectGraphType
{
    private readonly IInventoryRepository _inventoryRepository;

    public InventoryQuery(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;

        Field<ListGraphType<InventoryType>>(
            "inventory",
            resolve: context => _inventoryRepository.GetAllInventories()
        );
    }
}
