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

        public GameObject CreateAsteroid(int index)
        {
            return new GameObject("Asteroid").
                    AddSpriteRenderer(_asteroidData._asteroidStructs[index].Sprite).
                    AddPolygonCollider2D().
                    AddRigidbody2D(0,0)
                ; 
        }
    }
}