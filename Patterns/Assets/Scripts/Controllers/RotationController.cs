using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class RotationController: IExecute, ICleanData
    {
        private readonly GameObject _player;

        private readonly GameContext _gamePoolContext;

        private float _horizontal, _vertical;
        private readonly float _alignmentAngle = 90;
        private readonly IMouseInput _horizontalInput,_verticalInput;
        //подключить мышь
        public RotationController( (IMouseInput x, IMouseInput y) mouse, GameContext gamePoolContext)
        {
            _gamePoolContext = gamePoolContext;
            _horizontalInput = mouse.x;
            _verticalInput = mouse.y;
            _horizontalInput.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInput.AxisOnChange += VerticalOnAxisOnChange;
        }
        public void Execute(float deltaTime)
        {
            var angle = Mathf.Atan2(_vertical, _horizontal) * Mathf.Rad2Deg;
            _gamePoolContext.PlayerModel.PlayerStruct.Player.transform.rotation = Quaternion.AngleAxis(angle-_alignmentAngle, Vector3.forward);
        }
        public void CleanData()
        {
            _horizontalInput.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInput.AxisOnChange -= VerticalOnAxisOnChange;
        }
        
        private void VerticalOnAxisOnChange(float value)
        {
            _vertical += value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal += value;
        }
        
        
    }
}