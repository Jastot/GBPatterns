using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class AsteroidProvider: MonoBehaviour, IEnemy
    {
        public event Action<int> OnTriggerEnterChange;
        public void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID());
        }

        public void AddDamage(float damage)
        {
            throw new NotImplementedException();
        }

        public void Move(Vector3 point)
        {
            throw new NotImplementedException();
        }

        
    }
}