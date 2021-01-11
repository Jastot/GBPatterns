using UnityEngine;

namespace Asteroids.Decorator
{
    public class Point: IPoint
    {

        public GameObject PointModification { get; }

        public Point(GameObject pointModification)
        {
            PointModification = pointModification;
        }
        
    }
}