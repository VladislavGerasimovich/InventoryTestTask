using UnityEngine;

namespace Items
{
    public class DraggableItem : MonoBehaviour
    {
        [SerializeField] private string _type;

        private Transform _parentTransform;

        public bool InInventory { get; private set; }

        public string Type => _type;

        private void Awake()
        {
            _parentTransform = transform.parent;
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