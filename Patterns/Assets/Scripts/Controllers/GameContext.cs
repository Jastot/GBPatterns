using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class GameContext
    {
        public PlayerModel PlayerModel;
        public List<BulletModel> BulletModels;
        public Camera MainCamera;
        public GameContext()
        {
            BulletModels = new List<BulletModel>();
        }

        public void AddPlayerModel(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }

        public void AddCamera(Camera camera)
        {
            MainCamera = camera;
        }

        public void AddInteractiveModelList(BulletModel bulletModel)
        {
            BulletModels.Add(bulletModel);
        }

        public void RemoveInteractiveModelList(int index)
        {
            BulletModels.RemoveAt(index);
        }
    }
}