using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class BulletFactory: IBulletFactory
    {
        private readonly BulletData _bulletData;

        public BulletFactory(BulletData bulletData)
        {
            _bulletData = bulletData;
        }
        public BulletData GiveBulletData()
        {
            return _bulletData;
        }

        public GameObject CreateBullet(int index)
        {
            return new GameObject($"{index}").
                    AddSpriteRenderer(_bulletData._bulletStructe[index].Sprite).
                    AddPolygonCollider2D().
                    AddRigidbody2D(1,0)
                ; 
        }
    }
}