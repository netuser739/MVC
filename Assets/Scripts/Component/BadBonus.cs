using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Game
{
    public class BadBonus : Bonus, IRotation
    {
        [SerializeField] private CounterOfBonus _counter;

        [SerializeField] private Unit _player;

        private float yRotation = 0f;

        public override void Awake()
        {
            base.Awake();

            if (!_player)
            {
                Debug.Log("NOT Unit Component!");
            }
        }

        public override void Update()
        {
            base.Update();
            Rotate();
        }

        protected override void Interaction()
        {
            IsInteractable = false;

            if (gameObject.tag == "SpeedDownBonus") _player.Speed = 2f;
            if (gameObject.tag == "DefeatBonus") Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        public void Rotate()
        {
            yRotation += _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}