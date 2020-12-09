﻿using System.IO;
using UnityEngine;

namespace PatternsChudakovGA
{
    [CreateAssetMenu(fileName = "MainData", menuName = "Data/MainData")]
    public sealed class MainData: ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _bulletDataPath;
        private PlayerData _player;
        private BulletData _bullet;

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }
                return _player;
            }
        }
    
        public BulletData Bullet
        {
            get
            {
                if (_bullet == null)
                {
                    _bullet = Load<BulletData>("Data/" + _bulletDataPath);
                }

                return _bullet;
            }
        }
        
        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));


    }
}