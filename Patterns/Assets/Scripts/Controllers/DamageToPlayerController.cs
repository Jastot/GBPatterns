using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class DamageToPlayerController : IInitialization, ICleanData
    {
        
        private readonly List<AsteroidProvider> _getEnemies;
        private readonly List<BulletStruct> _bulletStructs;
        private readonly int _getInstanceID;
        public DamageToPlayerController(List<AsteroidProvider> getEnemies,List<BulletStruct> bulletStructs, int getInstanceID)
        {
            _getEnemies = getEnemies;
            _bulletStructs = bulletStructs;
            _getInstanceID = getInstanceID;
        }
        public void Initialization()
        {
            foreach (var enemy in _getEnemies)
            {
                enemy.OnTriggerEnterChange += EnemyOnOnTriggerEnterChange;
            }
        }
        private void EnemyOnOnTriggerEnterChange(int value)
        {
            if (value == _getInstanceID)
            {
                Debug.Log("Players id: "+_getInstanceID);
            }

            for (int i = 0; i < _bulletStructs.Count; i++)
            {
              if (value == _bulletStructs[i].Bullet.GetInstanceID())
              {
                  Debug.Log("Bullet id: " + i);   
              }  
            }
            
        }
        public void CleanData()
        {
            foreach (var enemy in _getEnemies)
            {
                enemy.OnTriggerEnterChange -= EnemyOnOnTriggerEnterChange;
            }
        }
    }
}