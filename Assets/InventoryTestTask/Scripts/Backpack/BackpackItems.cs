using Items;
using System.Collections.Generic;
using UnityEngine;

namespace Backpack
{
    public class BackpackItems : MonoBehaviour
    {
        [SerializeField] private List<BackpackItem> _items;

        public void PutItem(DraggableItem draggableItem)
        {
            foreach (var item in _items)
            {
                if(item.Type == draggableItem.Type)
                {
                    draggableItem.SetParent(item.transform);
                    ItemMove itemMove = draggableItem.GetComponent<ItemMove>();
                    itemMove.SetInventoryPosition(item.Position);

                    return;
                }
            }
        }
    }
}