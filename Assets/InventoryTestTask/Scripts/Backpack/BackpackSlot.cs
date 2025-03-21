using UnityEngine;

namespace Backpack
{
    public class BackpackSlot : MonoBehaviour
    {
        private Vector3 _position;

        public bool IsBusy { get; private set; }
        public string Type { get; private set; }

        public Vector3 Position => _position;

        private void Awake()
        {
            _position = transform.position;
        }

        public void Reserve(string type)
        {
            IsBusy = true;
            Type = type;
        }
    }
}