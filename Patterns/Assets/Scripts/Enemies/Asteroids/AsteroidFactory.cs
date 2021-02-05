using UnityEngine;

namespace PatternsChudakovGA
{
    public class AsteroidFactory: IAsteroidsFactory
    {
        private readonly AsteroidData _asteroidData;

        public AsteroidFactory(AsteroidData asteroidData)
        {
            _asteroidData = asteroidData;
        }
        
        public AsteroidData GiveAsteroidData()
        {
            return _asteroidData;
        }

        public GameObject CreateAsteroid(int index,int name)
        {
            return new GameObject($"{name}").
                    AddSpriteRenderer(_asteroidData._asteroidStructs[index].Sprite).
                    AddPolygonCollider2D(true).
                    AddRigidbody2D(40,0)
                ; 
        }
    }
}