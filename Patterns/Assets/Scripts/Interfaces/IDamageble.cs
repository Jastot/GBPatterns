using System;

namespace PatternsChudakovGA
{
    public interface IDamageble
    {
        void AddDamage(float damage);
        event Action<float,int> LookAtHealth;
    }
}