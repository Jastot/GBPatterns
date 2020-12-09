using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class InputController : IExecute
    {
       // private readonly IInputButton _inputFire;
       // private readonly Vector3 _mouse;
       // private readonly IInputButton _inputAcceleretion;
        private readonly IUserInputs _horizontal;
        private readonly IUserInputs _vertical;

        public InputController((IUserInputs inputHorizontal, IUserInputs inputVertical) input)
            //,
            //IInputButton inputFire,Vector3 mouse, IInputButton inputAcceleretion)
        {
            //_inputFire = inputFire;
           // _mouse = mouse;
            //_inputAcceleretion = inputAcceleretion;
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }
        
        
        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
           // _inputAcceleretion.GetButton();
           // _inputFire.GetButton();
        }
    }
    
}