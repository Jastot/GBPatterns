using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    [CreateAssetMenu(fileName = "Bullets", menuName = "Data/Bullets")]
    public sealed class BulletData: ScriptableObject
    {
        public List<BulletStruct> _bulletStructe;
    }
}