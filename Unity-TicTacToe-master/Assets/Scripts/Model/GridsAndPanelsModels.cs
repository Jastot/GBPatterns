using UnityEngine;
using UnityEngine.UI;

namespace MVVM_Chudakov
{
    public class GridsAndPanelsModels
    {
        public buttonView[] buttonList;
        public GameOverView gameOverPanel;
        public RestartView restartButton;

        public GridsAndPanelsModels(buttonView[] _buttonList,GameOverView _gameOverPanel,RestartView _restartButton)
        {
            buttonList = _buttonList;
            gameOverPanel = _gameOverPanel;
            restartButton = _restartButton;
        }
    }
}