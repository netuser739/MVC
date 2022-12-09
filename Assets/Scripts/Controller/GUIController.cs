using Game;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

namespace Game
{
    public class GUIController : MonoBehaviour
    {
        [SerializeField] private GameObject WinWindow;
        [SerializeField] private GameObject DefeatWindow;
        [SerializeField] private Text points;
        [SerializeField] private Button resetButton;

        public GameObject _WinWindow { get => WinWindow; }
        public GameObject _DefeatWindow { get => DefeatWindow; }
        public Button _resetButton { get => resetButton; }
        public Text Points { get => points; set => points = value; }

        private void Awake()
        {
            gameObject.SetActive(true);
            WinWindow.SetActive(false);
            DefeatWindow.SetActive(false);
            resetButton.gameObject.SetActive(false);
        }
    }
}