using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class InputAcceleration: IInputButton
    {
        public event Action<bool> AxisOnChange;
        
        public void GetButton()
        {
            AxisOnChange.Invoke(Input.GetKeyDown(KeyCode.LeftShift));
        }
    }
}