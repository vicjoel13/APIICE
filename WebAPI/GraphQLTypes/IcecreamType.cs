using GraphQL.Types;
using WebAPI.Models;

public class IcecreamType : ObjectGraphType<Icecream>
{
    public IcecreamType()
    {
        Field(x => x.Flavor).Description("The flavor of the icecream.");
        Field(x => x.Count).Description("The count of the icecream.");
        Field(x => x.IsSeasonFlavor).Description("Indicates if the icecream flavor is seasonal.");
    }
}