
using System;
using UnityEngine.UI;

namespace MVVM_Chudakov
{
    public class GameViewModel:  IGameViewModel
    {
        private TurnModel _turnModel;
        private readonly GridsAndPanelsModels _gridsAndPanelsModels;
        private readonly GameOverView _gameOver;
        private readonly RestartView _restartView;
        private bool winFlag;

        public GameViewModel(TurnModel turnModel,GridsAndPanelsModels gridsAndPanelsModels)
        {
            _turnModel = turnModel;
            _gridsAndPanelsModels = gridsAndPanelsModels;
            _gameOver = gridsAndPanelsModels.gameOverPanel;
            _restartView = gridsAndPanelsModels.restartButton;
            winFlag = false;
           
            _turnModel.player = TurnsState.X;
            _gameOver.gameObject.SetActive(false);
            _turnModel.count = 0;
            _restartView.gameObject.SetActive(false);
            _restartView.setGameViewModel(this);
            _gameOver.setGridAndPanelModels(gridsAndPanelsModels);
            _restartView.Initialize();
            for (int i = 0; i < _gridsAndPanelsModels.buttonList.Length; i++)
            {
                _gridsAndPanelsModels.buttonList[i].SetZero();
                _gridsAndPanelsModels.buttonList[i].CurrentState = TurnsState.None;
            }
            
        }
        
        
        
        public void GameOver(bool isItDraw)
        {
            if (winFlag == false)
            {
                SetBoardInteractable(false);
                _gameOver.SetGameOverText(Convert.ToString(_turnModel.player), isItDraw);
                ShowRestartButton(true);
                winFlag = true;
            }
        }
        
        public void Restart()
        {
            _turnModel.player = TurnsState.X;
            _turnModel.count = 0;
            _restartView.gameObject.SetActive(false);
            _gameOver.gameObject.SetActive(false);
            // gameOverPanel.SetActive(false);
            winFlag = false;
            for (int i = 0; i < _gridsAndPanelsModels.buttonList.Length; i++)
            {
                _gridsAndPanelsModels.buttonList[i].SetZero();
                _gridsAndPanelsModels.buttonList[i].CurrentState = TurnsState.None;
            }
           
            SetBoardInteractable(true);
        }
        
        public void ChangeSides()
        {
            _turnModel.player = (_turnModel.player == TurnsState.X)
                ? _turnModel.player = TurnsState.O
                : _turnModel.player = TurnsState.X;
            //playerSide = (playerSide == "X") ? "O" : "X"; // Note: Capital Letters for "X" and "O"
        }
        
        public void ShowRestartButton(bool enabled)
        {
            _restartView.gameObject.SetActive(enabled);
        }
        
        // public void SetGameOverText(string value)
        // {
        //     //неверно. надо перенести в вью такое...
        //     _gridsAndPanelsModels.gameOverPanel.enabled = true;
        //     _gridsAndPanelsModels.gameOverPanel.GetComponentInChildren<Text>().text = value;
        // }
        public void SetBoardInteractable(bool toggle)
        {
            for (int i = 0; i < _gridsAndPanelsModels.buttonList.Length; i++)
            {
                _gridsAndPanelsModels.buttonList[i].GetComponentInParent<Button>().interactable = toggle;
            }
        }

      
    }
}