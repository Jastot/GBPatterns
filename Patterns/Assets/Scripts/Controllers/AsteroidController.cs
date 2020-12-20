namespace PatternsChudakovGA
{
    public class AsteroidController : IExecute
    {
        private readonly AsteroidInitialization _asteroidInitialization;
        private readonly GameContext _gameContext;
        private readonly int _onDisplay;
        private int _spawned;

        public AsteroidController(AsteroidInitialization asteroidInitialization, GameContext gameContext, int onDisplay)
        {
            _asteroidInitialization = asteroidInitialization;
            _gameContext = gameContext;
            _onDisplay = onDisplay;
            _spawned = 0;
        }

        public void Execute(float deltaTime)
        {
            if (_spawned < _onDisplay)
            { 
                _asteroidInitialization.Initialize(_gameContext.EnemiesStartPosotionses[_spawned].StartPosition);
                _spawned++;
            }
        }

    }
}