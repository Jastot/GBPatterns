using UnityEngine;

namespace PatternsChudakovGA
{
    public interface IBulletFactory
    {
        BulletData GiveBulletData();
        GameObject CreateBullet(int index,int name);
    }
}