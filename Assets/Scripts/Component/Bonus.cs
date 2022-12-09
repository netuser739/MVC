using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game
{
    public abstract class Bonus : MonoBehaviour, IExecute, IFly
    {

        private bool _isInteractable;
        protected Color _color;
        private Renderer _renderer;
        private Collider _collider;

        [SerializeField] public float _heightFly;
        [SerializeField] public float _rotationSpeed;

        private Vector3 flyOffset = Vector3.up * 0.5f;

        public bool IsInteractable 
        {
            get => _isInteractable;

            set
            {
                _isInteractable = value;

                _renderer.enabled = value;
                _collider.enabled = value;

            }
        }

        public virtual void Awake()
        {
            if (!TryGetComponent<Renderer>(out _renderer))
            {
                Debug.Log("No Renderer Component!");
            }

            if (TryGetComponent<Collider>(out _collider))
            {
                Debug.Log("No Collider Component!");
            }

            IsInteractable = true;
            _color = Random.ColorHSV();
            _renderer.sharedMaterial.color = _color;

            _heightFly = 1f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interaction();
            }
        }

        protected abstract void Interaction();        

        public virtual void Update()
        {
            Fly();
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _heightFly), transform.position.z) + flyOffset;
        }
    }
}