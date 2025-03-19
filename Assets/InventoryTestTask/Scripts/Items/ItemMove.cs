using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Items
{
    [RequireComponent(typeof(Collider))]
    public class ItemMove : MonoBehaviour
    {
        private float _speed;
        private Coroutine _coroutine;
        private Collider _collider;
        private Vector3 _startPosition;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _startPosition = transform.position;
            _speed = 2f;
        }

        private IEnumerator RunCoroutine(Vector3 position, bool inInventory)
        {
            _collider.enabled = false;

            while (enabled)
            {
                transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);

                if(Vector3.Distance(transform.position, position) < 0.01f)
                {
                    StopCoroutine(_coroutine);
                    _coroutine = null;

                    if(inInventory == false)
                    {
                        _collider.enabled = true;
                    }
                }

                yield return null;
            }

        }

        public void SetPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        public void SetStartPosition()
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(RunCoroutine(_startPosition, false));
            }
        }

        public void SetInventoryPosition(Vector3 newPosition)
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(RunCoroutine(newPosition, true));
            }
        }
    }
}