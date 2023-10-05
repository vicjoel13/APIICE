using GraphQL.Types;

public class InventoryInputType : InputObjectGraphType
{
    public InventoryInputType()
    {
        Name = "InventoryInput";

        // Shop input
        Field<NonNullGraphType<ShopInputType>>("shop");

        // Employee input
        Field<NonNullGraphType<EmployeeInputType>>("employee");

        // Icecream input
        Field<NonNullGraphType<IcecreamInputType>>("icecream");

        // Date
        Field<NonNullGraphType<StringGraphType>>("date");
    }
}
