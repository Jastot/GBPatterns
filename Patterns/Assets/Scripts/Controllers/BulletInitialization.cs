using System;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class BulletInitialization
    {
        private readonly BulletPool _bulletPool;
        private readonly GameContext _gameContext;
        private readonly BulletLifeController _bulletLifeController;

        public BulletInitialization(BulletPool bulletPool, GameContext gameContext, BulletLifeController bulletLifeController)
        {
            _bulletPool = bulletPool;
            _gameContext = gameContext;
            _bulletLifeController = bulletLifeController;
        }
        public void Initialize()
        {
            var enemy = _bulletPool.GetAmmo("Bullet");
            var playerTransform = _gameContext.PlayerModel.PlayerStruct.Player.transform;
            var speed = _gameContext.BulletModels[Convert.ToInt32(_bulletPool.GiveMeName())].BulletStruct.Speed;
            enemy.transform.localPosition = playerTransform.localPosition + playerTransform.up;
            enemy.transform.localRotation = playerTransform.rotation;
            enemy.gameObject.SetActive(true);
            enemy.GetComponent<Rigidbody2D>().AddForce(enemy.transform.up * speed);
        }
    }
}