using Items.SO;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class AllItems : MonoBehaviour
    {
        private List<DraggableItem> _items;

        public void Init()
        {
            _items = new List<DraggableItem>();
        }

        public void CreateItem(Item item)
        {
            DraggableItem draggableItem = Instantiate(item.DraggableItemPrefab, transform);
            draggableItem.Init(item.Type);
            _items.Add(draggableItem);
        }

        public DraggableItem GetItemByType(string type)
        {
            foreach (DraggableItem item in _items)
            {
                if(item.Type == type)
                {
                    return item;
                }
            }

            return null;
        }
    }
}