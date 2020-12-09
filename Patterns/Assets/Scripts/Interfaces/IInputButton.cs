using System;

namespace PatternsChudakovGA
{
    public interface IInputButton
    {
        event Action<bool> AxisOnChange;
        void GetButton();
    }
}