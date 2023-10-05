using GraphQL.Types;
using Models.DataModels.RoleSystem;

public class InventoryType : ObjectGraphType<Inventory>
{
    public InventoryType()
    {
        Field(x => x.Store).Description("The shop where the icecream is sold.");
        Field(x => x.Employee).Description("The employee responsible for the inventory.");
        Field(x => x.Flavor).Description("The icecream details in the inventory.");
        Field(x => x.Date, type: typeof(StringGraphType)).Description("The date of the inventory entry.");
    }
}
