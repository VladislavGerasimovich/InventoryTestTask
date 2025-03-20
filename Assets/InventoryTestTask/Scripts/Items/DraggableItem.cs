using UnityEngine;

namespace Items
{
    public class DraggableItem : MonoBehaviour
    {
        private Transform _parentTransform;

        public bool InInventory { get; private set; }
        public string Type { get; private set; }

        public void Init(string type)
        {
            _parentTransform = transform.parent;
            Type = type;
        }

        public void SetParent(Transform position)
        {
            transform.SetParent(position);
            InInventory = true;
        }

        public void SetParent()
        {
            transform.SetParent(_parentTransform);
            InInventory = false;
        }
    }
}