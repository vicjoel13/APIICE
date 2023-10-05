using GraphQL;
using GraphQL.Types;
using Models.DataModels.RoleSystem;

public class InventoryMutation : ObjectGraphType
{
    public InventoryMutation()
    {
        Field<InventoryType>(
            "addInventory",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<InventoryInputType>> { Name = "inventory" }
            ),
            resolve: context =>
            {
                var inventoryInput = context.GetArgument<Inventory>("inventory");

                // Lógica para añadir el inventario 

                var addedInventory = SaveToDatabase(inventoryInput);  // Esta es solo una función ficticia como ejemplo

                return addedInventory;  // Esta es la línea crucial. Estás devolviendo el inventario que acabas de añadir.
            }
        );
    }

    private Inventory SaveToDatabase(Inventory inventory)
    {
        // Aquí iría la lógica para guardar el inventario en la base de datos
        // Por ahora, solo devolvemos el mismo objeto para el ejemplo
        return inventory;
    }
}
