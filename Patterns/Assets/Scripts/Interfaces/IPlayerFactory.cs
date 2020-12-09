using UnityEngine;

namespace PatternsChudakovGA
{
    public interface IPlayerFactory
    {
        PlayerData GivePlayerData();
        GameObject CreatePlayer();
    }
}