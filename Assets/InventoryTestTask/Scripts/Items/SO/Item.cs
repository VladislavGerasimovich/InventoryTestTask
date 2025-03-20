using UnityEngine;

namespace Items.SO
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Items", order = 51)]
    public class Item : ScriptableObject
    {
        [SerializeField] private int _weight;
        [SerializeField] private string _name;
        [SerializeField] private int _id;
        [SerializeField] private string _type;
        [SerializeField] private DraggableItem _prefab;

        public string Type => _type;
        public string Name => _name;
        public int Id => _id;
        public DraggableItem DraggableItemPrefab => _prefab;
    }
}