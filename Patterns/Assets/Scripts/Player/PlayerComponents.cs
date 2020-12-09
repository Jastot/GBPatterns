using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    [Serializable]
    public sealed class PlayerComponents
    {
        public PolygonCollider2D PolygonCollider2D;
        public Rigidbody2D Rigidbody2D;
    }
}