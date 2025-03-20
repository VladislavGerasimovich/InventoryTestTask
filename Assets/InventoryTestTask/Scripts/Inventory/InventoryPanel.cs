using Items;
using System.Collections;
using UnityEngine;

namespace Inventory
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private InventoryItems _inventoryItems;
        [SerializeField] private AllItems _allItems;

        private CanvasGroup _canvasGroup;

        public Coroutine OpenRoutine { get; private set; }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void RunOpenRoutine()
        {
            OpenRoutine = StartCoroutine(OpenCoroutine());
        }

        public void Open()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
        }

        public void Close()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
        }

        private IEnumerator OpenCoroutine()
        {
            Open();
            DraggableItem draggableItem = null;

            while (enabled)
            {
                InventoryItem item = _inventoryItems.GetHoveredItem();
                draggableItem = item != null ? _allItems.GetItemByType(item.Type) : null;

                if (Input.GetMouseButtonUp(0))
                {
                    if(draggableItem != null && draggableItem.InInventory == true)
                    {
                        ItemMove itemMove = draggableItem.GetComponent<ItemMove>();
                        itemMove.Fall(draggableItem);
                    }

                    Close();
                    StopCoroutine(OpenRoutine);
                    OpenRoutine = null;
                }

                yield return null;
            }
        }
    }
}