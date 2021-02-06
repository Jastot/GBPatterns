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

        public AsteroidProvider CreateAsteroid(int type,int name)
        {
            _asteroid = _asteroidsFactory.CreateAsteroid(type,name);
            _asteroid.AddComponent<AsteroidProvider>();
            //нужно сделать спавнпоинтс.
           
            var localAsteroidStruct = (AsteroidStruct)AsteroidStruct[type].Clone();
            localAsteroidStruct.Asteroid = _asteroid;
            
            var AsteroidModel = new AsteroidModel(localAsteroidStruct);
            _spawned++;
            _gameContext.AddAsteroidModelToList(_asteroid.GetInstanceID(),AsteroidModel);
            return _asteroid.GetComponent<AsteroidProvider>();
        }
    
        public void Initialization() { }
    }
}