using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Inventory
{
    [RequireComponent(typeof(Button))]
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private string _type;

        private Dictionary<Entry, UnityAction<BaseEventData>> _events;
        private Button _button;

        public bool InZone { get; private set; }

        public string Type => _type;

        private void Start()
        {
            _events = new Dictionary<Entry, UnityAction<BaseEventData>>();
            _button = GetComponent<Button>();
            EventTrigger trigger = _button.gameObject.AddComponent<EventTrigger>();
            Entry enterTrigger = EntryFactory.Create(EventTriggerType.PointerEnter, OnPointerEnter);
            trigger.triggers.Add(enterTrigger);
            _events.Add(enterTrigger, OnPointerEnter);
            Entry exitTrigger = EntryFactory.Create(EventTriggerType.PointerExit, OnPointerExit);
            trigger.triggers.Add(exitTrigger);
            _events.Add(exitTrigger, OnPointerExit);
        }

        private void OnPointerEnter(BaseEventData _)
        {
            InZone = true;
        }

        private void OnPointerExit(BaseEventData _)
        {
            InZone = false;
        }
    }
}