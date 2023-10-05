using Models.DataModels.RoleSystem;
using System.Collections.Generic;

public interface IInventoryRepository
{
    IEnumerable<Inventory> GetAllInventories();
}
