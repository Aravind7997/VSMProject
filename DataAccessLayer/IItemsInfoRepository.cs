using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IItemsInfoRepository<ItemsInfo>
    {
        IEnumerable<ItemsInfo> GetAllItems();
        ItemsInfo GetItemById(int itemId);
        bool SaveItems(ItemsInfo itemsInfo);
        bool DeleteItems(ItemsInfo itemsInfo);
        bool UpdateItems(ItemsInfo itemsInfo);
    }
}
