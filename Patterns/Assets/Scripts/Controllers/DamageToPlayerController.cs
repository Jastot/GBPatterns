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
            //whatStackIn - id, что вызвало колизию
            //inWhatStackIn - id, с кем была совершена колизия(кто отследил)
            if (whatStackIn == _getInstanceID)
            {
                _gameContext.AsteroidModels[inWhatStackIn].AsteroidStruct.
                    AddDamage(_gameContext.PlayerModel.PlayerStruct.CollisionDamage);
                
                _gameContext.PlayerModel.PlayerStruct.
                    AddDamage(_gameContext.AsteroidModels[inWhatStackIn].AsteroidStruct.CollisionDamage);
            }

            foreach (var key in _gameContext.BulletModels)
            { 
                if (whatStackIn == key.Key)
                {
                    _gameContext.AsteroidModels[inWhatStackIn].
                        AsteroidStruct.AddDamage(_gameContext.BulletModels[whatStackIn].
                            BulletStruct.CurrentDamage);
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