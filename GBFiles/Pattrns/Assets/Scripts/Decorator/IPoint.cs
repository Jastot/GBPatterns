using UnityEngine;

namespace Asteroids.Decorator
{
    public interface IPoint
    {
        GameObject PointModification { get; }
    }
}