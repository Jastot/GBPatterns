using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    [Serializable]
    public struct PlayerStruct
    {
        public GameObject Player;
        public Vector3 StartPosition;
        public Sprite Sprite;
        
        public int Health;
        public float Speed;
    }
}