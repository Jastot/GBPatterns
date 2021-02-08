using System;
using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class AsteroidLifeController:  IInitialization,ICleanData
    {
        private readonly Dictionary<int,AsteroidModel> _asteroidStructs;
        private readonly AsteroidsPool _asteroidsPool;

        public AsteroidLifeController(Dictionary<int,AsteroidModel> asteroidStructs,AsteroidsPool asteroidsPool)
        {
            _asteroidStructs = asteroidStructs;
            _asteroidsPool = asteroidsPool;
        }
        public void Initialization()
        {
            foreach (var asteroidStruct in _asteroidStructs)
            {
                asteroidStruct.Value.AsteroidStruct.LookAtHealth += AsteroidStructOnLookAtHealth;
            }
        }

        private void AsteroidStructOnLookAtHealth(float strength,int id)
        {
            foreach (var asteroidStruct in _asteroidStructs)
            {
                if (asteroidStruct.Key == id)
                {
                    if (strength <= 0)
                    {
                        _asteroidsPool.ReturnToPool(asteroidStruct.Value.AsteroidStruct.Asteroid.transform);
                    }
                }
            }
        }

        public void CleanData()
        {
            foreach (var asteroidStruct in _asteroidStructs)
            {
                asteroidStruct.Value.AsteroidStruct.LookAtHealth -= AsteroidStructOnLookAtHealth;
            }
        }
    }
}