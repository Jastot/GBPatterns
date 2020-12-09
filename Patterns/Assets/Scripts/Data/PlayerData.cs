using UnityEngine;

namespace PatternsChudakovGA
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Player")]
    public sealed class PlayerData: ScriptableObject
    {
        public PlayerStruct PlayerStruct;
        public PlayerComponents PlayerComponents;
        
        public PlayerData(PlayerStruct playerStruct,PlayerComponents playerComponents)
        {
            PlayerStruct = playerStruct;
            PlayerComponents = playerComponents;
        }
    }
}