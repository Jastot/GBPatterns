using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;


namespace PatternsChudakovGA
{
    public sealed class BulletPool
    {
        private BulletCreator _bulletCreator;
        private readonly Dictionary<string, HashSet<GameObject>> _bulletPool;
        private readonly int _capacityPool;
        private readonly GameContext _gameContext;
        private int _count;
        private Transform _rootPool;
        private string picked;
        
        public BulletPool(int capacityPool,BulletFactory bulletFactory,GameContext gameContext)
        {
            _gameContext = gameContext;
            // _bulletInitialization = new BulletInitialization();
            _bulletCreator = new BulletCreator(bulletFactory, _gameContext);
            _bulletPool = new Dictionary<string, HashSet<GameObject>>();
            _count = 0;
            _capacityPool = capacityPool;
            
            if (!_rootPool)
            {
                _rootPool = new
                    GameObject(PoolManager.POOL_AMMONATION).transform;
            }
        }

        public GameObject GetAmmo(string type)
        {
            GameObject result = GetBullet(GetListBullets(type));
            return result;
        }
        private HashSet<GameObject> GetListBullets(string type)
        {
            return _bulletPool.ContainsKey(type) ? _bulletPool[type] :
                _bulletPool[type] = new HashSet<GameObject>();
        }
        private GameObject GetBullet(HashSet<GameObject> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null )
            {
                
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = _bulletCreator.CreateBullet(0,_count);
                     ReturnToPool(instantiate.transform);
                     enemies.Add(instantiate);
                }
                _count++;
                GetBullet(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            picked = enemy.name;
            return enemy;
        }
        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public string GiveMeName()
        {
            return picked;
        }
        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}