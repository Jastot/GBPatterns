
using UnityEngine.UI;

namespace MVVM_Chudakov
{
    public class GameViewModel: IInitialize, IGameViewModel
    {
        private TurnModel _turnModel;
        private readonly GridsAndPanelsModels _gridsAndPanelsModels;
        private readonly GameOverView _gameOver;
        private readonly RestartView _restartView;

        public GameViewModel(TurnModel turnModel,GridsAndPanelsModels gridsAndPanelsModels)
        {
            _turnModel = turnModel;
            _gridsAndPanelsModels = gridsAndPanelsModels;
            _gameOver = gridsAndPanelsModels.gameOverText;
            _restartView = gridsAndPanelsModels.restartButton;
        }
        
        public void GameOver()
        {
            SetBoardInteractable(false);
            SetGameOverText(_turnModel.player + " Wins!"); // Note the space after the first " and Wins!"
            ShowRestartButton(true);
        
        }
        
        public void Restart()
        {
            _turnModel.player = TurnsState.X;
            _turnModel.count = 0;

            // restartButton.SetActive(false);
            // playerSide = "X";
            // moveCount = 0;
            // gameOverPanel.SetActive(false);
            //
            // for (int i = 0; i < buttonList.Length; i++)
            // {
            //     buttonList[i].text = "";
            // }
            //
            // SetBoardInteractable(true);
        }
        
        public void ChangeSides()
        {
            _turnModel.player = (_turnModel.player == TurnsState.X)
                ? _turnModel.player = TurnsState.O
                : _turnModel.player = TurnsState.X;
            //playerSide = (playerSide == "X") ? "O" : "X"; // Note: Capital Letters for "X" and "O"
        }
        
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
        public void ShowRestartButton(bool bol)
        {
            _gridsAndPanelsModels.restartButton.SetActive(bol);
        }
        
        public void SetGameOverText(string value)
        {
            _gridsAndPanelsModels.gameOverPanel.SetActive(true);
            _gridsAndPanelsModels.gameOverText.text = value;
        }
        public void SetBoardInteractable(bool toggle)
        {
            for (int i = 0; i < _gridsAndPanelsModels.buttonList.Length; i++)
            {
                _gridsAndPanelsModels.buttonList[i].GetComponentInParent<Button>().interactable = toggle;
            }
        }

      
    }
}