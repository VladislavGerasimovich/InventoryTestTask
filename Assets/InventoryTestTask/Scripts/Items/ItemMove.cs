using System.Collections;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(ItemCollisionHandler))]
    public class ItemMove : MonoBehaviour
    {
        private float _speed;
        private Coroutine _coroutine;
        private Collider _collider;
        private Rigidbody _rigidbody;
        private ItemCollisionHandler _collisionHandler;
        private float _distanceOffset;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
            _collisionHandler = GetComponent<ItemCollisionHandler>();
            _speed = 5f;
            _distanceOffset = 0.01f;
        }

        private IEnumerator RunCoroutine(Vector3 position)
        {
            _collider.enabled = false;

            while (enabled)
            {
                transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, position) < _distanceOffset)
                {
                    StopCoroutine(_coroutine);
                    _coroutine = null;
                }

                yield return null;
            }
        }

        public void SetPosition(Vector3 newPosition)
        {
            _collider.isTrigger = true;
            _rigidbody.isKinematic = true;

            if (_collisionHandler.IsCrossed == true && newPosition.y < transform.position.y)
            {
                transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);

                return;
            }

            transform.position = newPosition;
        }

        public void Fall(DraggableItem draggableItem)
        {
            if (_coroutine == null)
            {
                draggableItem.SetParent();
                _collider.enabled = true;
                _collider.isTrigger = false;
                _rigidbody.isKinematic = false;
            }
        }

        public void SetInventoryPosition(Vector3 newPosition)
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(RunCoroutine(newPosition));
            }
        }
    }
}