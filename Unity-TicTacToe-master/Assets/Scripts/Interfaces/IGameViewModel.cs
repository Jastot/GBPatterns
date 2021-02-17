namespace MVVM_Chudakov
{
    public interface IGameViewModel
    {
        void GameOver(bool draw);
        void Restart();
        void ChangeSides();
    }
}