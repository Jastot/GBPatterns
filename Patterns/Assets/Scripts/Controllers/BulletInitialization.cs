using System;
using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class BulletInitialization
    {
        private readonly BulletPool _bulletPool;
        private readonly GameContext _gameContext;
        private readonly BulletLifeController _bulletLifeController;
        private BulletStruct localbulletStruct;
    
        public BulletInitialization(BulletPool bulletPool, GameContext gameContext, BulletLifeController bulletLifeController)
        {
            _bulletPool = bulletPool;
            _gameContext = gameContext;
            _bulletLifeController = bulletLifeController;
        }

        public void Initialize()
        {
            _bulletPool.GetAmmo("Bullet");
            localbulletStruct = _gameContext.BulletModels[Convert.ToInt32(_bulletPool.GiveMeName())]
                .BulletStruct;

            var playerTransform = _gameContext.PlayerModel.PlayerStruct.Player.transform;
            var speed = localbulletStruct.Speed;
            localbulletStruct.Bullet.transform.localPosition = playerTransform.localPosition + playerTransform.up;
            localbulletStruct.Bullet.transform.localRotation = playerTransform.rotation;
            localbulletStruct.Bullet.gameObject.SetActive(true);
            localbulletStruct.Bullet.GetComponent<Rigidbody2D>()
                .AddForce(localbulletStruct.Bullet.transform.up * speed);
            _bulletLifeController.AddBulletStruct(localbulletStruct);
            
        }
    }
}