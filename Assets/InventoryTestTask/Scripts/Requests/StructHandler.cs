using Backpack;
using Inventory;
using UnityEngine;

namespace Requests
{
    [RequireComponent(typeof(PostStruct))]
    [RequireComponent(typeof(POSTRequest))]
    public class StructHandler : MonoBehaviour
    {
        [SerializeField] private BackpackItems _backpackItems;
        [SerializeField] private InventoryPanel _inventoryPanel;

        private PostStruct _postStruct;
        private POSTRequest _postRequest;

        private void Awake()
        {
            _postStruct = GetComponent<PostStruct>();
            _postRequest = GetComponent<POSTRequest>();
        }

        private void OnEnable()
        {
            _backpackItems.ItemPutted.AddListener(OnItemPutted);
            _inventoryPanel.ItemTaken.AddListener(OnItemTaken);
        }

        private void OnDisable()
        {
            _backpackItems.ItemPutted.RemoveListener(OnItemPutted);
            _inventoryPanel.ItemTaken.RemoveListener(OnItemTaken);
        }

        private void OnItemTaken(int id)
        {
            _postStruct.Result = _inventoryPanel.ItemTaken;
            _postStruct.Id = id;
            _postRequest.SendRequest(_postStruct);
        }

        private void OnItemPutted(int id)
        {
            _postStruct.Result = _backpackItems.ItemPutted;
            _postStruct.Id = id;
            _postRequest.SendRequest(_postStruct);
        }
    }
}