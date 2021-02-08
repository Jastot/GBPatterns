using System.Collections;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class ChangeGun: GameHandler
    {
        private readonly int _numberOfBullets;
        private float time;
        private float maxtime;
        private bool itstriple;

        public ChangeGun(int numberOfBullets)
        {
            itstriple = false;
            _numberOfBullets = numberOfBullets;
            maxtime = 330.0f;
        }
        private IEnumerator ModifeAGun()
        {
            time = 0;
            while ( time < maxtime )
            {
                time += Time.deltaTime;
                itstriple = true;
                yield return null;
            }
            base.Handle();
        }

        public override IGameHandler Handle()
        {
            StartCoroutine(ModifeAGun());
            return this;
        }

        public bool TripleModeIsOn()
        {
            return itstriple;
        }
    }
}