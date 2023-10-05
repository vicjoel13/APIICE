using GraphQL.Types;

public class IcecreamInputType : InputObjectGraphType
{
    public IcecreamInputType()
    {
        Name = "IcecreamInput";
        Field<NonNullGraphType<StringGraphType>>("flavor");
        Field<NonNullGraphType<IntGraphType>>("count");
        Field<NonNullGraphType<BooleanGraphType>>("is_season_flavor");
    }
}
