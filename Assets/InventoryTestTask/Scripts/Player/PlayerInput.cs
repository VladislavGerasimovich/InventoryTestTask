using DragAndDrop;
using Inventory;
using Items;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private DragAndDropHandler _dragAndDropHandler;
        [SerializeField] private InventoryPanel _inventoryPanel;
        [SerializeField] private LayerMask _itemsLayerMask;
        [SerializeField] private LayerMask _backpackLayerMask;

        private Coroutine _raycastRoutine;
        private Coroutine _waitRoutine;

        public void RunRaycastRoutine()
        {
            _raycastRoutine = StartCoroutine(RaycastRoutine());
        }

        private IEnumerator RaycastRoutine()
        {
            while (enabled)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _itemsLayerMask) == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        ItemMove item = hit.collider.GetComponent<ItemMove>();
                        _dragAndDropHandler.StartDragRoutine(item);
                        _waitRoutine = StartCoroutine(WaitRoutine());
                    }
                }

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _backpackLayerMask) == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        _inventoryPanel.RunOpenRoutine();
                        _waitRoutine = StartCoroutine(WaitRoutine());
                    }
                }

                yield return null;
            }
        }

        private IEnumerator WaitRoutine()
        {
            StopCoroutine(_raycastRoutine);
            _raycastRoutine = null;

            while (enabled)
            {
                if(_dragAndDropHandler.DragRoutine == null && _inventoryPanel.OpenRoutine == null)
                {
                    StopCoroutine(_waitRoutine);
                    _raycastRoutine = StartCoroutine(RaycastRoutine());
                }

                yield return null;
            }
        }
    }
}