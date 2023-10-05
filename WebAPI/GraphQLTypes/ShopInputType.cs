using GraphQL.Types;

public class ShopInputType : InputObjectGraphType
{
    public ShopInputType()
    {
        Name = "ShopInput";
        Field<NonNullGraphType<StringGraphType>>("name");
    }
}
