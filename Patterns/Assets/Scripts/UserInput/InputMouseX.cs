using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class InputMouseX: IMouseInput
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.MOUSEX));
        }
    }
}