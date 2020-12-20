using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class AsteroidsCreation: IInitialization
    {
        // ASTEROIDcREATION
        private readonly IAsteroidsFactory _asteroidsFactory;
        private readonly GameContext _gameContext;
        private readonly AsteroidData _asteroidData;
        private GameObject _asteroid;
        private List<AsteroidStruct> AsteroidStruct;
        private int _spawned = 0;

        public AsteroidsCreation(IAsteroidsFactory asteroidsFactory, GameContext gameContext)
        {
            _asteroidsFactory = asteroidsFactory;
            _gameContext = gameContext;
            _asteroidData = asteroidsFactory.GiveAsteroidData();
            AsteroidStruct = _asteroidData._asteroidStructs;
            
        }

        public AsteroidProvider CreateAsteroid(int type)
        {
            _asteroid = _asteroidsFactory.CreateAsteroid(type);
            _asteroid.AddComponent<AsteroidProvider>();

            AsteroidStruct[type].Asteroid = _asteroid;
            var AsteroidModel = new AsteroidModel(AsteroidStruct[type]);
            _spawned++;
            return _asteroid.GetComponent<AsteroidProvider>();
        }
    
        public void Initialization() { }
    }
}