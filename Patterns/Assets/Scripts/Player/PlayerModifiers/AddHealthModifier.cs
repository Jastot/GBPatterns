namespace PatternsChudakovGA
{
    internal sealed class AddHealthModifier: PlayerModifier
    {
        private readonly int _health;

        public AddHealthModifier(PlayerStruct player, int health) : base(player)
        {
            _health = health;
        }
        
        public override void Handle()
        {
            _player.Health += _health;
            base.Handle();
        }
    }
}