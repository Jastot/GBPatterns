using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class PlayerInitialization: IInitialization
    {
        
        private readonly IPlayerFactory _playerFactory;
        private GameObject _player;

        public PlayerInitialization(IPlayerFactory playerFactory, GameContext gameContext)
        {

            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
            var _playerStruct = (PlayerStruct)_playerFactory.GivePlayerData().PlayerStruct.Clone();
            _player.transform.position = _playerStruct.StartPosition;
            _playerStruct.Player = _player;
            var _playerComponents = _playerFactory.GivePlayerData().PlayerComponents;
            _playerComponents.Rigidbody2D = _playerStruct.Player.GetComponent<Rigidbody2D>();
            _playerComponents.PolygonCollider2D = _playerStruct.Player.GetComponent<PolygonCollider2D>();
            var playerModel = new PlayerModel(_playerStruct,_playerComponents);
            gameContext.AddPlayerModel(playerModel);
        }
        
        public void Initialization() { }
        
        public GameObject GetPlayer()
        {
            return _player;
        }

        public Transform GetPlayerTransform()
        {
            return _player.transform;
        }

        public Rigidbody2D GetPlayersRigidbody2D()
        {
            return _player.GetComponent<Rigidbody2D>();
        }
    }
}