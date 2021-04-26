using ORMDataManager.Library.Models;
using System.Collections.Generic;

namespace ORMDataManager.Library.DataAccess
{
    public interface IInventoryData
    {
        List<InventoryModel> GetInventory();
        void SaveInventoryRecord(InventoryModel item);
    }
}