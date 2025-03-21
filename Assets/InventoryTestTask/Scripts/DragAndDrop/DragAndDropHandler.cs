using Backpack;
using Items;
using System.Collections;
using UnityEngine;

namespace DragAndDrop
{
    public class DragAndDropHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask _backpackLayerMask;
        [SerializeField] private Camera _mainCamera;

        public Coroutine DragRoutine { get; private set; }

        public void StartDragRoutine(ItemMove item)
        {
            DragRoutine = StartCoroutine(Drag(item));
        }

        public IEnumerator Drag(ItemMove item)
        {
            Vector3 screenPosition;
            Vector3 worldPosition;
            float cameraOffset = Mathf.Abs(_mainCamera.transform.position.z) - Mathf.Abs(Camera.main.nearClipPlane - item.transform.position.z);

            while (enabled)
            {
                screenPosition = Input.mousePosition;
                screenPosition.z = Camera.main.nearClipPlane + cameraOffset;
                worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                item.SetPosition(worldPosition);

                if (Input.GetMouseButtonUp(0))
                {
                    StopCoroutine(DragRoutine);
                    DragRoutine = null;
                    Drop(item);
                }

                yield return null;
            }
        }

        public void Drop(ItemMove item)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            DraggableItem draggableItem = item.GetComponent<DraggableItem>();

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _backpackLayerMask) == true)
            {
                BackpackSlots backpackitems = hit.collider.GetComponent<BackpackSlots>();
                backpackitems.PutItem(draggableItem);

                return;
            }

            draggableItem.SetParent();
            item.Fall(draggableItem);
        }
    }
}