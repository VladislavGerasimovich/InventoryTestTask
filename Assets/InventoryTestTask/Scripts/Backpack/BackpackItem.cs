using UnityEngine;

namespace Backpack
{
    public class BackpackItem : MonoBehaviour
    {
        [SerializeField] private string _type;

        private Vector3 _position;

        public string Type => _type;
        public Vector3 Position => _position;

        private void Awake()
        {
            _position = transform.position;
        }
    }
}