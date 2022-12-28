using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public struct PlayerData
    {
        public string Name;
        public Vector3 Position;
        public Quaternion Rotation;
        public int Health;
        public float Speed;
        public bool IsDead;

        public PlayerData(Player player)
        {
            Name = player.name;
            Position = player.transform.position;
            Rotation = player.transform.rotation;
            Health = player.Health;
            Speed = player.Speed;
            IsDead = player.IsDead;
        }
    }

    [RequireComponent(typeof(Rigidbody))]
    public class Player : Unit
    {

        PlayerData _playerData;
        private ISaveData _saveData;

        public override void Awake()
        {
            base.Awake();

            Health = 100;

            _saveData = new JSONPlayerData(gameObject.name + ".json");
            _playerData = new PlayerData(this);

            _saveData.Save(_playerData);
        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * Speed);
            }
        }
    }
}