using UnityEngine;
using UnityEngine.UI;

namespace MVVM_Chudakov
{
    public class RestartView: MonoBehaviour, ICleanData, IInitialize
    {
        [SerializeField]private Button _button;
        private IGameViewModel _gameViewModel;

        public RestartView(IGameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }
        
        public void CleanData()
        {
            throw new System.NotImplementedException();
        }

        public void Initialize()
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(_gameViewModel.Restart);
        }
    }
}