using UnityEngine;

namespace Asteroids.Task_3
{
    public class MageFactory: IFactory
    {
        private readonly string _type;
        private readonly float _health;

        public MageFactory(string type, float health)
        {
            _type = type;
            _health = health;
        }
        public void Create()
        {
            Debug.Log($"Create: Type: {_type} Health: {_health}");
        }
    }
}