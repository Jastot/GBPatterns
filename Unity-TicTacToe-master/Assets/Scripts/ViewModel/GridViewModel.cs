using System;
using UnityEngine;

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
            
            
            for (int i = 0; i < _gridsAndPanelsModels.buttonList.Length; i++)
            {
                _gridsAndPanelsModels.buttonList[i].addModel(this,i);
                _gridsAndPanelsModels.buttonList[i].Initialize();
            }
        }
        
        public void EndTurn()
        {
            _turnModel.count++;
            
            if (_gridsAndPanelsModels.buttonList[0].CurrentState ==_turnModel.player &&
                _gridsAndPanelsModels.buttonList[1].CurrentState ==_turnModel.player &&
                _gridsAndPanelsModels.buttonList[2].CurrentState ==_turnModel.player)
            {
                _gameViewModel.GameOver(false);
            }
        
            if (_gridsAndPanelsModels.buttonList[3].CurrentState ==_turnModel.player && 
                _gridsAndPanelsModels.buttonList[4].CurrentState ==_turnModel.player&&
                _gridsAndPanelsModels.buttonList[5].CurrentState ==_turnModel.player)
            {
                _gameViewModel.GameOver(false);
            }
        
            if (_gridsAndPanelsModels.buttonList[6].CurrentState ==_turnModel.player && 
                _gridsAndPanelsModels.buttonList[7].CurrentState ==_turnModel.player &&
                _gridsAndPanelsModels.buttonList[8].CurrentState ==_turnModel.player)
            {
                _gameViewModel.GameOver(false);
            }
        
            if (_gridsAndPanelsModels.buttonList[0].CurrentState ==_turnModel.player && 
                _gridsAndPanelsModels.buttonList[3].CurrentState ==_turnModel.player &&
                _gridsAndPanelsModels.buttonList[6].CurrentState ==_turnModel.player)
            {
                _gameViewModel.GameOver(false);
            }
        
            if (_gridsAndPanelsModels.buttonList[1].CurrentState ==_turnModel.player&& 
                _gridsAndPanelsModels.buttonList[4].CurrentState ==_turnModel.player&&
                _gridsAndPanelsModels.buttonList[7].CurrentState ==_turnModel.player)
            {
                _gameViewModel.GameOver(false);
            }
        
            if (_gridsAndPanelsModels.buttonList[2].CurrentState ==_turnModel.player && 
                _gridsAndPanelsModels.buttonList[5].CurrentState ==_turnModel.player&&
                _gridsAndPanelsModels.buttonList[8].CurrentState ==_turnModel.player)
            {
                _gameViewModel.GameOver(false);
            }
        
            if (_gridsAndPanelsModels.buttonList[0].CurrentState ==_turnModel.player && 
                _gridsAndPanelsModels.buttonList[4].CurrentState ==_turnModel.player &&
                _gridsAndPanelsModels.buttonList[8].CurrentState ==_turnModel.player)
            {
                _gameViewModel.GameOver(false);
            }
        
            if (_gridsAndPanelsModels.buttonList[2].CurrentState ==_turnModel.player && 
                _gridsAndPanelsModels.buttonList[4].CurrentState ==_turnModel.player&&
                _gridsAndPanelsModels.buttonList[6].CurrentState ==_turnModel.player)
            {
                _gameViewModel.GameOver(false);
            }

            if (_turnModel.count >= 9)
            {
                _gameViewModel.GameOver(true);
                // SetGameOverText("Its a draw.");
                // ShowRestartButton(true);
                // SetBoardInteractable(false);
            }
            _gameViewModel.ChangeSides();
        
        }

        public void SetState(buttonView buttonView,int i)
        {
            if (_turnModel.player == TurnsState.O)
            {
                buttonView.SetState(TurnsState.O);
                _gridsAndPanelsModels.buttonList[i].CurrentState = TurnsState.O;
            }
            else
            {
                buttonView.SetState(TurnsState.X);
                _gridsAndPanelsModels.buttonList[i].CurrentState = TurnsState.X;
            }
            buttonView.button.interactable = false;
            EndTurn();
        }
    }
}