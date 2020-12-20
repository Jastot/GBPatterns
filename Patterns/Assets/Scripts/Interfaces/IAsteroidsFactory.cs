using UnityEngine;

namespace PatternsChudakovGA
{
    public interface IAsteroidsFactory
    {
        AsteroidData GiveAsteroidData();
        GameObject CreateAsteroid(int index);
    }
}