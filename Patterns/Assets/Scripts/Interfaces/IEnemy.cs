using System;

namespace PatternsChudakovGA
{
    public interface IEnemy: IDamageble, IMove
    {
        event Action<int> OnTriggerEnterChange;
    }
}