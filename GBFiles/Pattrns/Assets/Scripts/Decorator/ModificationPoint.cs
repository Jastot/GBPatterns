using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed  class ModificationPoint: ModificationWeapon
    {
        
        private readonly Vector3 _position;
        private readonly IPoint _point;
        private readonly Quaternion _rotation;

        protected override Weapon AddModification(Weapon weapon)
        {
            var point = Object.Instantiate(_point.PointModification,_position, _rotation);
            return weapon;
        }

        public ModificationPoint(Vector3 position, Quaternion rotation,IPoint point)
        {
            _rotation = rotation;
            _position = position;
            _point = point;
        }
    }
}