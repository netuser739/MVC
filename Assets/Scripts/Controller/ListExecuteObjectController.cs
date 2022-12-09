using System.Collections;
using System;
using UnityEngine;

namespace Game
{
    public class ListExecuteObjectController : IEnumerator, IEnumerable
    {
        private int _index = -1;

        private IExecute[] _interactiveObjects;

        public int Length => _interactiveObjects.Length;

        public object Current => _interactiveObjects[_index];

        public IExecute this[int curr] 
        { 
            get => _interactiveObjects[curr]; 
            private set => _interactiveObjects[curr] = value; 
        }

        public ListExecuteObjectController(Bonus[] bonuses)
        {
            for(int i = 0; i < bonuses.Length; i++)
            {
                if(bonuses[i] is IExecute intObj) Add(intObj);
            }
        }

        public void Add(IExecute execute)
        {
            if(_interactiveObjects == null)
            {
                _interactiveObjects = new[] {execute};
                return;
            }
            
            Array.Resize(ref _interactiveObjects, Length + 1);
            _interactiveObjects[Length - 1] = execute;
        }


        public bool MoveNext()
        {
            if(_index == Length - 1)
            {
                return false;
            }
            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}