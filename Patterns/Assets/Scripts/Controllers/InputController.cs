using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class InputController : IExecute
    {   
        private readonly IInputButton _inputFire;
        private readonly IMouseInput _mouseX;
        private readonly IMouseInput _mouseY;
       // private readonly IInputButton _inputAcceleretion;
        private readonly IUserInputs _horizontal;
        private readonly IUserInputs _vertical;

        public InputController((IUserInputs inputHorizontal, IUserInputs inputVertical) input, 
        (IMouseInput x, IMouseInput y) mouse,IInputButton inputFire)
            //IInputButton inputFire, IInputButton inputAcceleretion)
        {
            _inputFire = inputFire;
            _mouseX = mouse.x;
            _mouseY = mouse.y;
            //_inputAcceleretion = inputAcceleretion;
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }
        
        
        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _mouseX.GetAxis();
            _mouseY.GetAxis();
           // _inputAcceleretion.GetButton();
            _inputFire.GetButton();
        }
    }
    
}