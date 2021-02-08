using UnityEditor;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class PlayerLifeController:  IInitialization, ICleanData
    {
        private readonly PlayerStruct _playerStruct;

        public PlayerLifeController(PlayerStruct playerStruct)
        {
            _playerStruct = playerStruct;
        }
        public void Initialization()
        {
            _playerStruct.LookAtHealth += PlayerStructOnLookAtHealth;
        }

        private void PlayerStructOnLookAtHealth(float health,int id)
        {
            
            if (health <= 0)
            {
                GameObject.Destroy(_playerStruct.Player);
            }
        }

        public void CleanData()
        {
            throw new System.NotImplementedException();
        }
    }
}