using System.Collections.Generic;

namespace PatternsChudakovGA
{
    public class BulletLifeController: IExecute
    {

        private List<BulletStruct> _bulletStructs;

        private void LifeTimeCounting()
        {
            
        }

        public void AddBulletStruct(BulletStruct bulletStruct)
        {
            _bulletStructs.Add(bulletStruct);
        }
        
        public void Execute(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}