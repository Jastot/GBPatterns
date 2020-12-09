using System;

namespace PatternsChudakovGA
{
    public interface IUserInputs
    {
        event Action<float> AxisOnChange;
        void GetAxis();
    }
}