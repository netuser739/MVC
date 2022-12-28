using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Game
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Unit _player;
        [SerializeField] private Bonus[] _winBonuses;
        [SerializeField] private CounterOfBonus _counter;
        [SerializeField] private GUIController GUI;

        private InputController _inputController;
        private CameraController _cameraController;
        private ListExecuteObjectController _executeObject;
        private int MenuIsActive = 0;

        IEnumerator interactivEnum;

        // Start is called before the first frame update
        private void Awake()
        {
            _inputController = new InputController(_player);

            _executeObject = new ListExecuteObjectController(_winBonuses);

            _cameraController = new CameraController(_player.transform, Camera.main.transform);

            _executeObject.Add(_inputController);
            _executeObject.Add(_cameraController);

            interactivEnum = _executeObject.GetEnumerator();

            _counter.CountOfWinBonus = 0;
        }

        void Update()
        {
            GUI.Points.text = $"Points: {_counter.CountOfWinBonus}/{_winBonuses.Length}";

            if (_counter.CountOfWinBonus == _winBonuses.Length)
            {
                GUI._WinWindow.SetActive(true);
                GUI._resetButton.gameObject.SetActive(true);
            }

            if (Input.GetKey(KeyCode.Escape) && MenuIsActive == 0)
            {
                GUI._MenuWindow.SetActive(true);
                MenuIsActive = 1;
            }
            if (Input.GetKey(KeyCode.Q) && MenuIsActive == 1)
            {
                GUI._MenuWindow.SetActive(false);
                MenuIsActive = 0;
            }

            if (!_player)
            {
                GUI._DefeatWindow.SetActive(true);
                GUI._resetButton.gameObject.SetActive(true);
            }

            if (_executeObject.MoveNext())
            {
                IExecute temp = (IExecute)_executeObject.Current;
                temp.Update();
            }
            else
            {
                _executeObject.Reset();
            }
        }

        public void SceneLoad()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}