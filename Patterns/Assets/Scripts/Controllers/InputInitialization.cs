using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class InputInitialization: IInitialization

    {
        private readonly GameContext _gameContext;
        private IUserInputs _InputHorizontal;
        private IUserInputs _InputVertical;
        private IInputButton _InputAcseleration;
        private IInputButton _InputFire;
        private Vector3 _Mouse;

        public InputInitialization(GameContext gameContext)
        {
            _gameContext = gameContext;
            _InputHorizontal = new InputHorizontal();
            _InputVertical = new InputVertical();
            
            _InputAcseleration = new InputAcceleration();
            _InputFire = new InputFire();
        }

        public Vector3 GetMouse()
        {
           return _Mouse = Input.mousePosition - _gameContext.MainCamera.WorldToScreenPoint(
                _gameContext.PlayerModel.PlayerStruct.Player.transform.position);
           
        }
        
        public IInputButton GetAcceleration()
        {
            return _InputAcseleration;
        }

        public IInputButton GetFire()
        {
            return _InputFire;
        }

        public void Initialization()
        { }
        public (IUserInputs inputHorizontal, IUserInputs inputVertical) GetInputHorVert()
        {
            (IUserInputs inputHorizontal, IUserInputs inputVertical) result = (_InputHorizontal, _InputVertical);
            return result;
        }
    }
}