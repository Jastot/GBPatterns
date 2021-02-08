using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class PlayerFactory: IPlayerFactory
    {
        
        private readonly PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }
        
        public GameObject CreatePlayer()
        {
            return new GameObject("Player").
                AddSpriteRenderer(_playerData.PlayerStruct.Sprite).
                AddPolygonCollider2D(false).
                AddRigidbody2D(20,0)
            ;
        }
        public PlayerData GivePlayerData()
        {
            return _playerData;
        }
    }
}