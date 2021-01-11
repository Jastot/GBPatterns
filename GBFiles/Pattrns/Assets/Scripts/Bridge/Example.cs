using UnityEngine;

namespace Asteroids.Bridge
{
    internal sealed class Example : MonoBehaviour
    {
        private void Start()
        {
            var enemy = new Enemy(new MagicalAttack(), new Infantry());
            var angel = new Enemy(new MagicalAttack(), new Levetation());
            var archer = new Enemy(new RangeAttack(), new Infantry());
            var helicopter = new Enemy(new AirAttack(), new Fly());
        }
    }
}
