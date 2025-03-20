using Environment;
using UnityEngine;

namespace Items
{
    public class ItemCollisionHandler : MonoBehaviour
    {
        public bool IsCrossed { get; private set; }

        private void OnTriggerStay(Collider other)
        {
            if(other.TryGetComponent(out Ground ground) == true)
            {
                IsCrossed = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Ground ground) == true)
            {
                IsCrossed = false;
            }
        }
    }
}