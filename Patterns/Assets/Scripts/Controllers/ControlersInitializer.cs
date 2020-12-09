
using UnityEngine;

namespace PatternsChudakovGA
{
    public class ControlersInitializer: MonoBehaviour
    {
        [SerializeField] private MainData _data;

        private Controllers _controllers;
        private GameContext _gameContext;

        private void Start()
        {
            _gameContext = new GameContext();
            _gameContext.AddCamera(Camera.main);
            var inputInitialization = new InputInitialization(_gameContext);
            var playerFactory = new PlayerFactory(_data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory,_gameContext);
            
            _controllers = new Controllers();
            _controllers.Add(playerInitialization);
            _controllers.Add(inputInitialization);
            _controllers.Add(new InputController(inputInitialization.GetInputHorVert()));
                //,
                //inputInitialization.GetFire(),inputInitialization.GetMouse(),inputInitialization.GetAcceleration()));
            _controllers.Add(new MoveController(inputInitialization.GetInputHorVert(), _gameContext));
            _controllers.Add(new RotationController(inputInitialization.GetInputHorVert(), _gameContext));
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