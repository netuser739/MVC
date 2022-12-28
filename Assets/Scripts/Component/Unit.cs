using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;

        private float _speed = 5f;
        private int _health = 100;
        private bool _isDead;

        public int Health 
        { 
            get => _health; 

            set
            {
                if(value >= 0 && value <= 100)
                {
                    _health = value;
                }
                else
                {
                    _health = 100;
                }
            }
        }

        public float Speed { get => _speed; set => _speed = value; }
        public bool IsDead { get => _isDead; set => _isDead = value; }

        public virtual void Awake()
        {
            if(!TryGetComponent<Transform>(out _transform))
            {
                Debug.Log("No Transform Component!");
            }

            if(TryGetComponent<Rigidbody>(out _rb))
            {
                Debug.Log("No Rigidbody Component!");

            }

        }

        public abstract void Move(float x, float y, float z);
    }
}