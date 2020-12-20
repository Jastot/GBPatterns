using UnityEngine;

namespace PatternsChudakovGA
{
    public class AsteroidInitialization: IInitialization
    {
        private readonly AsteroidsPool _asteroidsPool;

        public AsteroidInitialization(AsteroidsPool asteroidsPool,int baseCount)
        {
            _asteroidsPool = asteroidsPool;
        }

        public void Initialize(Vector3 position)
        {
            var enemy = _asteroidsPool.GetEnemy("Asteroid"); 
            enemy.transform.position = position;
            enemy.gameObject.SetActive(true);
        }
        public void Initialization() { }
    }
}