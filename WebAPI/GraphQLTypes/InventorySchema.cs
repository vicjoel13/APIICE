using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

public class InventorySchema : Schema
{
    public InventorySchema(IServiceProvider provider)
        : base(provider)
    {
        Query = provider.GetRequiredService<InventoryQuery>();
        // Mutation = provider.GetRequiredService<InventoryMutation>();
    }
}
