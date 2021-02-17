using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MVVM_Chudakov
{


    public class GameController : MonoBehaviour
    {
        
        
        
        // ох...какое ж п...
        // работает зато без багов.
        
        // public Text[] buttonList;
        // public GameObject gameOverPanel;
        // public Text gameOverText;
        // public GameObject restartButton;
        //
        // private string playerSide;
        // private int moveCount;
        //
        // void Awake()
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
        // void SetGameControllerReferenceOnButtons()
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
        //
        // public void EndTurn()
        // {
        //     moveCount++;
        //
        //     if (buttonList[0].text == playerSide && buttonList[1].text == playerSide &&
        //         buttonList[2].text == playerSide)
        //     {
        //         GameOver();
        //     }
        //
        //     if (buttonList[3].text == playerSide && buttonList[4].text == playerSide &&
        //         buttonList[5].text == playerSide)
        //     {
        //         GameOver();
        //     }
        //
        //     if (buttonList[6].text == playerSide && buttonList[7].text == playerSide &&
        //         buttonList[8].text == playerSide)
        //     {
        //         GameOver();
        //     }
        //
        //     if (buttonList[0].text == playerSide && buttonList[3].text == playerSide &&
        //         buttonList[6].text == playerSide)
        //     {
        //         GameOver();
        //     }
        //
        //     if (buttonList[1].text == playerSide && buttonList[4].text == playerSide &&
        //         buttonList[7].text == playerSide)
        //     {
        //         GameOver();
        //     }
        //
        //     if (buttonList[2].text == playerSide && buttonList[5].text == playerSide &&
        //         buttonList[8].text == playerSide)
        //     {
        //         GameOver();
        //     }
        //
        //     if (buttonList[0].text == playerSide && buttonList[4].text == playerSide &&
        //         buttonList[8].text == playerSide)
        //     {
        //         GameOver();
        //     }
        //
        //     if (buttonList[2].text == playerSide && buttonList[4].text == playerSide &&
        //         buttonList[6].text == playerSide)
        //     {
        //         GameOver();
        //     }
        //
        //     if (moveCount >= 9)
        //     {
        //         SetGameOverText("Its a draw.");
        //         ShowRestartButton(true);
        //         SetBoardInteractable(false);
        //
        //     }
        //
        //     ChangeSides();
        //
        // }
        //
        // void GameOver()
        // {
        //     SetBoardInteractable(false);
        //     SetGameOverText(playerSide + " Wins!"); // Note the space after the first " and Wins!"
        //     ShowRestartButton(true);
        //
        // }
        //
        // void ShowRestartButton(bool bol)
        // {
        //     restartButton.SetActive(bol);
        // }
        //
        // void SetGameOverText(string value)
        // {
        //     gameOverPanel.SetActive(true);
        //     gameOverText.text = value;
        // }
        //
        // void ChangeSides()
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
        // void SetBoardInteractable(bool toggle)
        // {
        //     for (int i = 0; i < buttonList.Length; i++)
        //     {
        //         buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        //     }
        // }
    }
}
