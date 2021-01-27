using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class GameContext
    {
        public PlayerModel PlayerModel;
        public List<BulletModel> BulletModels;
        public List<AsteroidModel> AsteroidModels;
        public List<EnemiesStartPosotions> EnemiesStartPosotionses;
        public Camera MainCamera;
        public GameContext()
        {
            BulletModels = new List<BulletModel>();
        }

        public void AddAllPositions(List<EnemiesStartPosotions> enemiesStartPosotions)
        {
            EnemiesStartPosotionses = enemiesStartPosotions;
        }
        public void AddPlayerModel(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }

        public void AddCamera(Camera camera)
        {
            MainCamera = camera;
        }
        public void AddAsteroidModelToList(AsteroidModel asteroidModel)
        {
            AsteroidModels.Add(asteroidModel);
        }

        public void AddInteractiveModelList(BulletModel bulletModel)
        {
            BulletModels.Add(bulletModel);
        }
    }
}