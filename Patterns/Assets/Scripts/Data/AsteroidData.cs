using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    [CreateAssetMenu(fileName = "Asteroids", menuName = "Data/Asteroids")]
    public sealed class AsteroidData: ScriptableObject
    {
        public List<AsteroidStruct> _asteroidStructs;
        public List<AsteroidComponents> _asteroidComponentses;
        public List<EnemiesStartPosotions> EnemiesStartPosotionses;
        public int GetCountOfAsteroids()
        {
            return _asteroidStructs.Count;
        }
    }
    
    
}