using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private List<InventoryItem> _items;
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
                foreach (InventoryItem item in _items)
                {
                    if(item.InZone == true)
                    {
                        draggableItem = _allItems.GetItemByType(item.Type);
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    if(draggableItem != null && draggableItem.InInventory == true)
                    {
                        ItemMove itemMove = draggableItem.GetComponent<ItemMove>();
                        draggableItem.SetParent();
                        itemMove.SetStartPosition();
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