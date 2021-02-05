namespace PatternsChudakovGA
{
    internal class PlayerModifier
    {
        protected PlayerStruct _player;
        protected PlayerModifier Next;

        public PlayerModifier(PlayerStruct player)
        {
            _player = player;
        }
        public void Add(PlayerModifier cm)
        {
            if (Next != null)
            {
                Next.Add(cm);
            }
            else
            {
                Next = cm;
            }
        }
        public virtual void Handle() => Next?.Handle();
    }
}