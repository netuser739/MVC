using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CounterOfBonus : MonoBehaviour
    {
        private int _countOfWinBonus;

        public int CountOfWinBonus { get => _countOfWinBonus; set => _countOfWinBonus = value; }

        public CounterOfBonus(int count)
        {
            _countOfWinBonus = count;
        }
    }
}