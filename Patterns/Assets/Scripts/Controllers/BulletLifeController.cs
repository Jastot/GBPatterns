using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class BulletLifeController:  IExecute
    {
        private readonly BulletPool _bulletPool;

        private List<BulletStruct> _bulletStructs;
        private List<BulletStruct> _deleteStructs;
        
        public BulletLifeController(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
            _bulletStructs = new List<BulletStruct>();
            _deleteStructs = new List<BulletStruct>();
        }

        public void AddBulletStruct(BulletStruct bulletStruct)
        {
            _bulletStructs.Add(bulletStruct);
        }

        public void RemoveBulletStrict(BulletStruct bulletStruct)
        {
            _bulletStructs.Remove(bulletStruct);
            
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0;i<_bulletStructs.Count;i++)
            {
                _bulletStructs[i].CurrentTime += deltaTime;
                if (_bulletStructs[i].CurrentTime >= _bulletStructs[i].MaxLifeTime)
                {
                    _bulletPool.ReturnToPoolByObject(_bulletStructs[i].Bullet);
                    _bulletStructs[i].CurrentTime = 0;
                    _deleteStructs.Add(_bulletStructs[i]);
                }
                
            }

            for (int i = 0; i < _deleteStructs.Count; i++)
            {
                RemoveBulletStrict(_deleteStructs[i]);
            }

            _deleteStructs.RemoveRange(0,_deleteStructs.Count);

        }
    }
}