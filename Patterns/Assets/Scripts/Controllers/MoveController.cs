using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class MoveController: IExecute, ICleanData
    {

        private readonly GameObject _player;

        private readonly GameContext _gamePoolContext;

        private float _horizontal, _vertical;

        private Vector3 _movement;

        private readonly IUserInputs _horizontalInput,_verticalInput;

        public MoveController((IUserInputs inputHorizontal, IUserInputs inputVertical) input,
            GameContext gamePoolContext)
        {
            _horizontalInput = input.inputHorizontal;
            _verticalInput = input.inputVertical;
            _horizontalInput.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInput.AxisOnChange += VerticalOnAxisOnChange;
            _gamePoolContext = gamePoolContext;
        }
        public void Execute(float deltaTime)
        {
            var speed = deltaTime * _gamePoolContext.PlayerModel.PlayerStruct.Speed;
            _movement.Set(_horizontal * speed, _vertical * speed, 0.0f);
            _gamePoolContext.PlayerModel.PlayerStruct.Player.transform.localPosition += _movement;
        }

        public void CleanData()
        {
            _horizontalInput.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInput.AxisOnChange -= VerticalOnAxisOnChange;
        }
        
        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }
    }
}