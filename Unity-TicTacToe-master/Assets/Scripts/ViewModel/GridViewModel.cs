using System;

namespace MVVM_Chudakov
{
    public class GridViewModel
    {
        private readonly TurnModel _turnModel;
        private readonly GridsAndPanelsModels _gridsAndPanelsModels;
        private readonly GameViewModel _gameViewModel;

        public GridViewModel(TurnModel turnModel,GridsAndPanelsModels gridsAndPanelsModels,GameViewModel gameViewModel)
        {
            _turnModel = turnModel;
            _gridsAndPanelsModels = gridsAndPanelsModels;
            _gameViewModel = gameViewModel;
        }
        
        public void EndTurn()
        {
            _turnModel.count++;
        
            if (_gridsAndPanelsModels.buttonList[0].text == Convert.ToString(_turnModel.player) &&
                _gridsAndPanelsModels.buttonList[1].text == Convert.ToString(_turnModel.player) &&
                _gridsAndPanelsModels.buttonList[2].text == Convert.ToString(_turnModel.player))
            {
                _gameViewModel.GameOver();
            }
        
            if (_gridsAndPanelsModels.buttonList[3].text == Convert.ToString(_turnModel.player) && 
                _gridsAndPanelsModels.buttonList[4].text == Convert.ToString(_turnModel.player) &&
                _gridsAndPanelsModels.buttonList[5].text == Convert.ToString(_turnModel.player))
            {
                _gameViewModel.GameOver();
            }
        
            if (_gridsAndPanelsModels.buttonList[6].text == Convert.ToString(_turnModel.player) && 
                _gridsAndPanelsModels.buttonList[7].text == Convert.ToString(_turnModel.player) &&
                _gridsAndPanelsModels.buttonList[8].text == Convert.ToString(_turnModel.player))
            {
                _gameViewModel.GameOver();
            }
        
            if (_gridsAndPanelsModels.buttonList[0].text == Convert.ToString(_turnModel.player) && 
                _gridsAndPanelsModels.buttonList[3].text == Convert.ToString(_turnModel.player) &&
                _gridsAndPanelsModels.buttonList[6].text == Convert.ToString(_turnModel.player))
            {
                _gameViewModel.GameOver();
            }
        
            if (_gridsAndPanelsModels.buttonList[1].text == Convert.ToString(_turnModel.player)&& 
                _gridsAndPanelsModels.buttonList[4].text == Convert.ToString(_turnModel.player )&&
                _gridsAndPanelsModels.buttonList[7].text == Convert.ToString(_turnModel.player))
            {
                _gameViewModel.GameOver();
            }
        
            if (_gridsAndPanelsModels.buttonList[2].text == Convert.ToString(_turnModel.player) && 
                _gridsAndPanelsModels.buttonList[5].text == Convert.ToString(_turnModel.player )&&
                _gridsAndPanelsModels.buttonList[8].text == Convert.ToString(_turnModel.player))
            {
                _gameViewModel.GameOver();
            }
        
            if (_gridsAndPanelsModels.buttonList[0].text == Convert.ToString(_turnModel.player) && 
                _gridsAndPanelsModels.buttonList[4].text == Convert.ToString(_turnModel.player) &&
                _gridsAndPanelsModels.buttonList[8].text == Convert.ToString(_turnModel.player))
            {
                _gameViewModel.GameOver();
            }
        
            if (_gridsAndPanelsModels.buttonList[2].text == Convert.ToString(_turnModel.player) && 
                _gridsAndPanelsModels.buttonList[4].text == Convert.ToString(_turnModel.player )&&
                _gridsAndPanelsModels.buttonList[6].text == Convert.ToString(_turnModel.player))
            {
                _gameViewModel.GameOver();
            }
        
            if (_turnModel.count >= 9)
            {
                SetGameOverText("Its a draw.");
                ShowRestartButton(true);
                SetBoardInteractable(false);
        
            }
        
            _gameViewModel.ChangeSides();
        
        }

        public void SetState(buttonView buttonView)
        {
            if (_turnModel.player == TurnsState.O)
                buttonView.SetState(TurnsState.O); 
            else
                buttonView.SetState(TurnsState.X);
            buttonView.button.interactable = false;
            EndTurn();
        }
    }
}