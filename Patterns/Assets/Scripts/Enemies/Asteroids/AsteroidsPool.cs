using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PatternsChudakovGA
{
    public sealed class AsteroidsPool
    {
        private readonly Dictionary<string, HashSet<AsteroidProvider>> _asteroidPool;
        private readonly int _capacityPool;
        private int _count;
        private Transform _rootPool;
        private AsteroidsCreation _asteroidsInitialization;
        public AsteroidsPool(int capacityPool,AsteroidFactory asteroidsFactory,GameContext gameContext)
        {
            _asteroidsInitialization = new AsteroidsCreation(asteroidsFactory,gameContext);
            _asteroidPool = new Dictionary<string, HashSet<AsteroidProvider>>();
            _count = 1;
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new
                    GameObject(PoolManager.POOL_ASTEROIDS).transform;
            }
        }

        public AsteroidProvider GetEnemy(string type)
        {
            AsteroidProvider result;
            switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type,
                        "Не предусмотрен в программе");
            }
            return result;
        }
        private HashSet<AsteroidProvider> GetListEnemies(string type)
        {
            return _asteroidPool.ContainsKey(type) ? _asteroidPool[type] :
                _asteroidPool[type] = new HashSet<AsteroidProvider>();
        }
        private AsteroidProvider GetAsteroid(HashSet<AsteroidProvider> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null )
            {
                
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = _asteroidsInitialization.CreateAsteroid(0);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }
                _count++;
                GetAsteroid(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }
        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}