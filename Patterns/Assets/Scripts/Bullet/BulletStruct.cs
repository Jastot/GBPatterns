using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    [Serializable]
    public sealed class BulletStruct : ICloneable
    {
        public GameObject Bullet;
        public Sprite Sprite;
        public float Speed;
        public float MaxLifeTime;
        public float CurrentTime;
        public object Clone()
        {
            return new BulletStruct() 
            { 
                Bullet = this.Bullet, 
                Sprite = this.Sprite,
                Speed = this.Speed, 
                MaxLifeTime = this.MaxLifeTime,
                CurrentTime = this.CurrentTime 
            };
        }
    }
}