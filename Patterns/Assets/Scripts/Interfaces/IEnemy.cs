using System;

namespace PatternsChudakovGA
{
    public interface IEnemy
    {
        event Action<int,int> OnTriggerEnterChange;
    }
}