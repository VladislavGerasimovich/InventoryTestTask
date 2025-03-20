using Inventory.Grid;
using Items;
using Items.SO;
using Player;
using System.Collections.Generic;
using UnityEngine;

namespace EntryPoint
{
    public class GameStart : MonoBehaviour
    {
        [SerializeField] private List<Item> _items;
        [SerializeField] private AllItems _allItems;
        [SerializeField] private InventoryGrid _grid;
        [SerializeField] private PlayerInput _playerInput;

        private void Start()
        {
            _allItems.Init();
            _grid.Init();

            foreach (var item in _items)
            {
                _allItems.CreateItem(item);
                _grid.AddItemToSlot(item);
            }

            _playerInput.RunRaycastRoutine();
        }
    }
}