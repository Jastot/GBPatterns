
using TMPro;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class ControlersInitializer: MonoBehaviour
    {
        [SerializeField] private MainData _data;
        [SerializeField] private int _countOfAsteroids = 5;
        [SerializeField] private int _countOfBullets = 5;
        [SerializeField] private int _AsteroidsOnDisplay = 5;
        private Controllers _controllers;
        private GameContext _gameContext;

        private void Start()
        {
            _gameContext = new GameContext();
            _gameContext.AddCamera(Camera.main);
            _gameContext.AddAllPositions(_data.AsteroidData.EnemiesStartPosotionses);
            var inputInitialization = new InputInitialization(_gameContext);
            var playerFactory = new PlayerFactory(_data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory,_gameContext);
            
            //
            var bulletsFactory = new BulletFactory(_data.BulletData);
            var bulletsPool = new BulletPool(_countOfBullets,bulletsFactory,_gameContext);
            var asteroidsFactory = new AsteroidFactory(_data.AsteroidData);
            var asteroidsPool = new AsteroidsPool(_countOfAsteroids,asteroidsFactory,_gameContext); 
            var asteroidsInitialization = new AsteroidInitialization(asteroidsPool,_countOfAsteroids);
            var asteroidsController = new AsteroidController(asteroidsInitialization,_gameContext,_AsteroidsOnDisplay);

            _controllers = new Controllers();
            _controllers.Add(playerInitialization);
            _controllers.Add(inputInitialization);
            _controllers.Add(asteroidsController);
            
            _controllers.Add(new InputController(inputInitialization.GetInputHorVert(),inputInitialization.GetMouse(),inputInitialization.GetFire()));
            _controllers.Add(new ShootingController(inputInitialization.GetFire(), bulletsPool, _gameContext));
            _controllers.Add(new MoveController(inputInitialization.GetInputHorVert(), _gameContext));
            _controllers.Add(new RotationController(inputInitialization.GetMouse(), _gameContext));
            _controllers.Add(new CameraController(playerInitialization.GetPlayerTransform(), _gameContext.MainCamera.transform));
            _controllers.Initialization();
        }
        
        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.CleanData();
        }
    }
}