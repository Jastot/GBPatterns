namespace Asteroids.Decorator
{
    internal abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;
        
        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon RemoveModification(Weapon Changingweapon, Weapon BasicWeapon);
        
        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void ApplyRemoveModification(Weapon weapon, Weapon BasicWeapon)
        {
            _weapon = RemoveModification(weapon,BasicWeapon);
        }
        
        public void Fire()
        {
            _weapon.Fire();
        }
    }
}
