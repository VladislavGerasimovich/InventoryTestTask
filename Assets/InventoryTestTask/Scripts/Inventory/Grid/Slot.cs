using UnityEngine;

namespace Inventory.Grid
{
    public class Slot : MonoBehaviour
    {
        public bool IsBusy { get; private set; }

        public void BlockUse()
        {
            IsBusy = true;
        }
    }
}