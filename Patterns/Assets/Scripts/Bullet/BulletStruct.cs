using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    [Serializable]
    public sealed class BulletStruct
    {
        public GameObject Bullet;
        public Sprite Sprite;
        public float Speed;
        public float MaxLifeTime;
        public float CurrentTime;
    }
}