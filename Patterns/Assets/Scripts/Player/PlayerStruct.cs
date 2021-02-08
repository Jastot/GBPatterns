using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    [Serializable]
    public struct PlayerStruct : ICloneable, IDamageble
    {
        public GameObject Player;
        public Vector3 StartPosition;
        public Sprite Sprite;
        public float CollisionDamage;
        public float Health;
        public float Speed;
        public object Clone()
        {
            return new PlayerStruct() 
            { 
                Player = this.Player, 
                Sprite = this.Sprite,
                Speed = this.Speed, 
                CollisionDamage = this.CollisionDamage,
                StartPosition = this.StartPosition,
                Health = this.Health 
            };
        }
        

        public void AddDamage(float damage)
        {
            Health -= damage;
            LookAtHealth.Invoke(Health,Player.GetInstanceID());
        }

        public event Action<float,int> LookAtHealth;
    }
}