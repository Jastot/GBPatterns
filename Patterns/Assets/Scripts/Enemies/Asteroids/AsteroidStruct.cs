using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    [Serializable]
    public class AsteroidStruct: IDamageble, ICloneable
    {
        public GameObject Asteroid;
        public Sprite Sprite;
        public float Strenght;
        public float Speed;
        public float CollisionDamage;
        public Vector3 StartPosition;
        public void AddDamage(float damage)
        {
            Strenght -= damage;
        }

        public object Clone()
        {
            return new AsteroidStruct() 
            { 
                Asteroid = this.Asteroid,
                Sprite = this.Sprite,
                Strenght = this.Strenght,
                Speed = this.Speed,
                CollisionDamage = this.CollisionDamage
            };
        }
    }
}