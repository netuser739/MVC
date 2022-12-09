using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class GoodBonus : Bonus
    {
        [SerializeField] private CounterOfBonus _counter;

        [SerializeField] private Unit _player;

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
            base .Update();
        }

        protected override void Interaction()
        {
            IsInteractable = false;
            
            if(gameObject.tag == "WinBonus") _counter.CountOfWinBonus++;

            if (gameObject.tag == "SpeedBoostBonus") _player.Speed = 15f;
        }
    }
}