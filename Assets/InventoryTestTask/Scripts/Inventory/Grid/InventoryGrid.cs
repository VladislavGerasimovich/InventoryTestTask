using Items.SO;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Grid
{
    [RequireComponent(typeof(InventoryItems))]
    public class InventoryGrid : MonoBehaviour
    {
        [SerializeField] private Slot _slotPrefab;
        [SerializeField] private InventoryItem _itemPrefab;
        [SerializeField] private int _slotsCount;

        private InventoryItems _inventoryItems;
        private List<Slot> _slots;

        public void Init()
        {
            _inventoryItems = GetComponent<InventoryItems>();
            _inventoryItems.Init();
            _slots = new List<Slot>();

            for (int i = 0; i < _slotsCount; i++)
            {
                Slot slot = Instantiate(_slotPrefab, transform);
                _slots.Add(slot);
            }
        }

        public void AddItemToSlot(Item item)
        {
            foreach (Slot slot in _slots)
            {
                if(slot.IsBusy == false)
                {
                    InventoryItem inventoryItem = Instantiate(_itemPrefab, slot.transform);
                    inventoryItem.Init(item.Type, item.Name);
                    _inventoryItems.AddItem(inventoryItem);
                    slot.BlockUse();

                    return;
                }
            }
        }
    }
}