namespace PatternsChudakovGA
{
    public sealed class PlayerModel
    {
        public PlayerStruct PlayerStruct;
        public PlayerComponents PlayerComponents;

        public PlayerModel(PlayerStruct playerStruct,PlayerComponents playerComponents)
        {
            PlayerStruct = playerStruct;
            PlayerComponents = playerComponents;
        }
    }
}