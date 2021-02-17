using UnityEngine;
using UnityEngine.UI;

namespace MVVM_Chudakov
{
    public class RestartView: MonoBehaviour, ICleanData, IInitialize
    {
        [SerializeField]private Button _button;
        private IGameViewModel _gameViewModel;

        public void setGameViewModel(IGameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }
        
        public void CleanData()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void Initialize()
        {
            CleanData();
            _button.onClick.AddListener(() => _gameViewModel.Restart());
        }
        
        
    }
}