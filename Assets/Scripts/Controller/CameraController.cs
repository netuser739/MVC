using UnityEngine;

namespace Game
{
    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _camera;
        private Vector3 _offset;

        public CameraController(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
            _offset = camera.position - player.position;
            _camera.LookAt(player);
        }

        public void Update()
        {
            _camera.position = _player.position + _offset;
        }
    }
}