using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class AsteroidProvider: MonoBehaviour, IEnemy
    {
        public event Action<int,int> OnTriggerEnterChange;
        public void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID(),this.gameObject.GetInstanceID());
        }

    }
}