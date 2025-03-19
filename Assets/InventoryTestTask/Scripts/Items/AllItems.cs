using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class AllItems : MonoBehaviour
    {
        [SerializeField] private List<DraggableItem> _items;

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