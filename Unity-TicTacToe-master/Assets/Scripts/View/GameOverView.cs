using UnityEngine;
using UnityEngine.UI;

namespace MVVM_Chudakov
{
    public class GameOverView : MonoBehaviour
    {
        private GridsAndPanelsModels _gridsAndPanelsModels;

        public void setGridAndPanelModels(GridsAndPanelsModels gridsAndPanelsModels)
        {
            _gridsAndPanelsModels = gridsAndPanelsModels;
        }
        
        public void SetGameOverText(string value, bool isItDraw)
        {
            _gridsAndPanelsModels.gameOverPanel.gameObject.SetActive(true);
            if (isItDraw)
                _gridsAndPanelsModels.gameOverPanel.GetComponentInChildren<Text>().text = "Its a draw.";
            else 
                _gridsAndPanelsModels.gameOverPanel.GetComponentInChildren<Text>().text = value + " Wins!";
        }
    }
}