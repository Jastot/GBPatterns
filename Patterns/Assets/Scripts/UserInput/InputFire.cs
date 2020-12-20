using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class InputFire: IInputButton
    {
        public event Action<bool> AxisOnChange;

        public void GetButton()
        {
            AxisOnChange.Invoke(Input.GetButtonDown(AxisManager.FIRE1));
        }
    }
}