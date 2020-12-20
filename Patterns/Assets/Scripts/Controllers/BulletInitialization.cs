using UnityEngine;

namespace PatternsChudakovGA
{
    public class BulletInitialization
    {
        private readonly BulletPool _bulletPool;
        private readonly GameContext _gameContext;

        public BulletInitialization(BulletPool bulletPool, GameContext gameContext)
        {
            _bulletPool = bulletPool;
            _gameContext = gameContext;
        }
        public void Initialize(float speed)
        {
            var enemy = _bulletPool.GetAmmo("Bullet"); 
            enemy.transform.position = _gameContext.PlayerModel.PlayerStruct.Player.transform.localPosition + Vector3.up;
            enemy.transform.rotation = _gameContext.PlayerModel.PlayerStruct.Player.transform.localRotation;
            enemy.gameObject.SetActive(true);
            enemy.GetComponent<Rigidbody2D>().AddForce(enemy.transform.forward * speed);
        }
    }
}