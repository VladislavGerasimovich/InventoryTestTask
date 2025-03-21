using Items;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Backpack
{
    public class BackpackSlots : MonoBehaviour
    {
        [SerializeField] private List<BackpackSlot> _slots;

        public UnityEvent<int> ItemPutted;

        public void AddItemToSlot(string type)
        {
            foreach (BackpackSlot slot in _slots)
            {
                if(slot.IsBusy == false)
                {
                    slot.Reserve(type);

                    return;
                }
            }
        }

        public void PutItem(DraggableItem draggableItem)
        {
            foreach (var item in _slots)
            {
                if(item.Type == draggableItem.Type)
                {
                    draggableItem.SetParent(item.transform);
                    ItemMove itemMove = draggableItem.GetComponent<ItemMove>();
                    itemMove.SetInventoryPosition(item.Position);
                    ItemPutted?.Invoke(draggableItem.Id);

                    return;
                }
            }
        }
    }
}