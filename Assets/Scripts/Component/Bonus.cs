using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game
{
    public struct BonusData
    {
        public Color Color;
        public Vector3 Position;
        public Quaternion Rotation;
        public string Tag;
        public bool IsInteractable;

        public BonusData(Bonus bonus)
        {
            Color = bonus.Color;
            IsInteractable = bonus.IsInteractable;
            Position = bonus.transform.position;
            Rotation = bonus.transform.rotation;
            Tag = bonus.tag;
        }
    }

    public abstract class Bonus : MonoBehaviour, IExecute, IFly
    {

        private bool _isInteractable;
        private Color color;
        private Renderer _renderer;
        private Collider _collider;

        [SerializeField] public float _heightFly;
        [SerializeField] public float _rotationSpeed;

        private Vector3 flyOffset = Vector3.up * 0.5f;

        private BonusData bonusData;
        private ISaveData saveData;

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

        public Color Color { get => color; set => color = value; }

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
            Color = Random.ColorHSV();
            _renderer.sharedMaterial.color = Color;

            _heightFly = 1f;

            saveData = new JSONBonudData(gameObject.name + ".json");
            bonusData = new BonusData(this);
            saveData.Save(bonusData);
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