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
        
        public int Health;
        public float Speed;
        public object Clone()
        {
            return new PlayerStruct() 
            { 
                Player = this.Player, 
                Sprite = this.Sprite,
                Speed = this.Speed, 
                StartPosition = this.StartPosition,
                Health = this.Health 
            };
        }

        public void AddDamage(float damage)
        {
            throw new NotImplementedException();
        }
    }
}