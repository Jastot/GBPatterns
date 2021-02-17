using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MVVM_Chudakov
{


    public class GridSpace : MonoBehaviour
    {

        public Button button;
        public Text buttonText;

        private GameController gameController;


        public void SetSpace()
        {
            buttonText.text = gameController.GetPlayerSide();
            button.interactable = false;
            gameController.EndTurn();
        }

        public void SetGameControllerReference(GameController controller)
        {
            gameController = controller;
        }
    }
}