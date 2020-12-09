using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class CameraController : ILateExecute
    {
        private readonly Transform _player;

        private readonly Transform _camera;

        private readonly Vector3 _offset;
        
        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _camera = mainCamera;
            _offset = _camera.position - _player.position;
        }
        
        public void LateExecute(float deltaTime)
        {
            _camera.position = _player.position + _offset;
        }
    }
}