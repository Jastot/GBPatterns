namespace PatternsChudakovGA
{
    internal sealed class AddSpeedModifier: PlayerModifier
    {
        private readonly float _speed;

        public AddSpeedModifier(PlayerStruct player,float speed) : base(player)
        {
            _speed = speed;
        }
        
        public override void Handle()
        {
            _player.Speed += _speed;
            base.Handle();
        }

    }
}