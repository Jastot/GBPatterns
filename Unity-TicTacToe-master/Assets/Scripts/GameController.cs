using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MVVM_Chudakov
{


    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameOverView gameOverPanel;
        [SerializeField] private RestartView restartButton;
        [SerializeField]public buttonView[] buttonList;


        private string playerSide;
        private int moveCount;

        private void Start()
        {
            TurnModel turnModel = new TurnModel();
            GridsAndPanelsModels gridsAndPanelsModels = new GridsAndPanelsModels(buttonList,gameOverPanel,restartButton);
            
            GameViewModel gameViewModel = new GameViewModel(turnModel,gridsAndPanelsModels);
            GridViewModel gridViewModel = new GridViewModel(turnModel,gridsAndPanelsModels,gameViewModel);
            
        }

        // private void Awake()
        // {
        //     SetGameControllerReferenceOnButtons();
        //     playerSide = "X";
        //     gameOverPanel.SetActive(false);
        //     moveCount = 0;
        //     restartButton.SetActive(false);
        //
        // }
        //
        //
        // public void SetGameControllerReferenceOnButtons()
        // {
        //     for (int i = 0; i < buttonList.Length; i++)
        //     {
        //         buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        //     }
        // }
        //
        // public string GetPlayerSide()
        // {
        //     return playerSide;
        // }
        // public void GameOver()
        // {
        //     SetBoardInteractable(false);
        //     SetGameOverText(playerSide + " Wins!");
        //     ShowRestartButton(true);
        //
        // }
        //
        // public void ShowRestartButton(bool bol)
        // {
        //     restartButton.SetActive(bol);
        // }
        //
        // public void SetGameOverText(string value)
        // {
        //     gameOverPanel.SetActive(true);
        //     gameOverText.text = value;
        // }
        //
        // public void ChangeSides()
        // {
        //     playerSide = (playerSide == "X") ? "O" : "X"; // Note: Capital Letters for "X" and "O"
        // }
        //
        // public void RestartGame()
        // {
        //     restartButton.SetActive(false);
        //     playerSide = "X";
        //     moveCount = 0;
        //     gameOverPanel.SetActive(false);
        //
        //     for (int i = 0; i < buttonList.Length; i++)
        //     {
        //         buttonList[i].text = "";
        //     }
        //
        //     SetBoardInteractable(true);
        // }
        //
        // public void SetBoardInteractable(bool toggle)
        // {
        //     for (int i = 0; i < buttonList.Length; i++)
        //     {
        //         buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        //     }
        // }
    }
}
