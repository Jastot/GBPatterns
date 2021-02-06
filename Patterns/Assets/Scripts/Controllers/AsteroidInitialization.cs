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

        public void Initialize()
        {
            var enemy = _asteroidsPool.GetEnemy("Asteroid");
            enemy.transform.position = new Vector3(Random.Range(-10f,10f),Random.Range(-10f,10f),0); ;
            enemy.gameObject.SetActive(true);
        }
        public void Initialization() { }
    }
}