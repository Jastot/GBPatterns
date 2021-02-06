using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class GameContext
    {
        public PlayerModel PlayerModel;
        public Dictionary<int,BulletModel> BulletModels;
        public Dictionary<int,AsteroidModel> AsteroidModels;
        public Camera MainCamera;
        public GameContext()
        {
            BulletModels = new Dictionary<int,BulletModel>();
            AsteroidModels = new Dictionary<int, AsteroidModel>();
        }
        
        public void AddPlayerModel(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }

        public void AddCamera(Camera camera)
        {
            MainCamera = camera;
        }
        public void AddAsteroidModelToList(int id,AsteroidModel asteroidModel)
        {
            AsteroidModels.Add(id,asteroidModel);
        }

        public void AddInteractiveModelList(int id,BulletModel bulletModel)
        {
            BulletModels.Add(id,bulletModel);
        }
    }
}