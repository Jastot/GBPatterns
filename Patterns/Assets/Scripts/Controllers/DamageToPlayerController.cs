using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class DamageToPlayerController : IInitialization, ICleanData
    {
        
        private readonly List<AsteroidProvider> _getEnemies;
        private readonly GameContext _gameContext;
        private readonly int _getInstanceID;
        public DamageToPlayerController(List<AsteroidProvider> getEnemies,GameContext gameContext, int getInstanceID)
        {
            _getEnemies = getEnemies;
            _gameContext = gameContext;
            _getInstanceID = getInstanceID;
        }
        public void Initialization()
        {
            foreach (var enemy in _getEnemies)
            {
                enemy.OnTriggerEnterChange += EnemyOnOnTriggerEnterChange;
            }
        }
        private void EnemyOnOnTriggerEnterChange(int whatStackIn,int inWhatStackIn)
        {
            //whatStackIn - что вызвало колизию
            //inWhatStackIn - с кем была совершена колизия(кто отследил)
            if (whatStackIn == _getInstanceID)
            {
                Debug.Log("Players id: "+_getInstanceID);
                Debug.Log("Asteroid health: " + _gameContext.AsteroidModels[inWhatStackIn].
                    AsteroidStruct.Strenght);
                
                _gameContext.AsteroidModels[inWhatStackIn].AsteroidStruct.
                    AddDamage(_gameContext.PlayerModel.PlayerStruct.CollisionDamage);
                
                _gameContext.PlayerModel.PlayerStruct.
                    AddDamage(_gameContext.AsteroidModels[inWhatStackIn].AsteroidStruct.CollisionDamage);
                
                Debug.Log("Asteroid health after damage: " + _gameContext.AsteroidModels[inWhatStackIn].
                    AsteroidStruct.Strenght);
            }

            for (int i = 0; i < _gameContext.BulletModels.Count; i++)
            {
              if (whatStackIn == _gameContext.BulletModels[i].BulletStruct.Bullet.GetInstanceID())
              {
                  Debug.Log("Bullet id: " + i);
                  Debug.Log("Asteroid health: " + _gameContext.AsteroidModels[inWhatStackIn].
                      AsteroidStruct.Strenght);
                  
                  // _gameContext.AsteroidModels[inWhatStackIn].AsteroidStruct.Strenght -=
                  //     _gameContext.BulletModels[whatStackIn].BulletStruct.CurrentDamage;
                  _gameContext.AsteroidModels[inWhatStackIn].
                      AsteroidStruct.AddDamage(_gameContext.BulletModels[whatStackIn].
                          BulletStruct.CurrentDamage);
                  
                  Debug.Log("Asteroid health after damage: " + _gameContext.AsteroidModels[inWhatStackIn].
                      AsteroidStruct.Strenght);
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