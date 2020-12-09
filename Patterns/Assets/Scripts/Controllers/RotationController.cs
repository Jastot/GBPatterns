using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class RotationController: IExecute
    {
        private readonly GameObject _player;

        private readonly GameContext _gamePoolContext;

        private float _horizontal, _vertical;

        private Vector3 _movement;

        private readonly IUserInputs _horizontalInput,_verticalInput;

        public RotationController((IUserInputs inputHorizontal, IUserInputs inputVertical) input,
            GameContext gamePoolContext)
        {
            _gamePoolContext = gamePoolContext;
        }
        public void Execute(float deltaTime)
        {
            var angle = Mathf.Atan2(_horizontal, _vertical) * Mathf.Rad2Deg;
            _gamePoolContext.PlayerModel.PlayerStruct.Player.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        
    }
}