using UnityEngine;
using UnityEngine.Events;

namespace Requests
{
    public class PostStruct : MonoBehaviour
    {
        public UnityEvent<int> Result;
        public int Id;
    }
}