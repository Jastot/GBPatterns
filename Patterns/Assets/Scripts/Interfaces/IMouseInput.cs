using System;

namespace PatternsChudakovGA
{
    public interface IMouseInput
    {
        event Action<float> AxisOnChange;
        
        void GetAxis();
    }
}