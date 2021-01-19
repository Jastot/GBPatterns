using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class BulletCreator: IInitialization
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly GameContext _gameContext;
        private GameObject _bullet;
        private int _spawned = 0;
        private List<BulletStruct> BulleStructs;
        private readonly BulletData _bulletData;
        
        public BulletCreator(IBulletFactory bulletFactory,GameContext gameContext)
        {
            
            _bulletFactory = bulletFactory;
            _gameContext = gameContext;
            _bulletData = _bulletFactory.GiveBulletData();
            BulleStructs = _bulletData._bulletStructe;
        }
        public GameObject CreateBullet(int type,int count)
        {
            _bullet = _bulletFactory.CreateBullet(type);
            BulleStructs[type].Bullet = _bullet;
            var bulletModel = new BulletModel(BulleStructs[type]);
            _spawned++;
            _gameContext.AddInteractiveModelList(bulletModel);
            return _bullet;
        }
        public void Initialization()
        {
            
        }
    }
}