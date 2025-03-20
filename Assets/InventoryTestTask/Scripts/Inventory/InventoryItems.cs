using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryItems : MonoBehaviour
    {
        private List<InventoryItem> _inventoryItems;

        public void Init()
        {
            _inventoryItems = new List<InventoryItem>();
        }

        public void AddItem(InventoryItem item)
        {
            _inventoryItems.Add(item);
        }

        public InventoryItem GetHoveredItem()
        {
            foreach (InventoryItem item in _inventoryItems)
            {
                if(item.InZone == true)
                {
                    return item;
                }
            }

            return null;
        }
    }
}