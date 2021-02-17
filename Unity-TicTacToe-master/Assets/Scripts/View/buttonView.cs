using UnityEngine;
using UnityEngine.UI;

namespace MVVM_Chudakov
{
    public class buttonView: MonoBehaviour, IInitialize,ICleanData
    {
        public Button button;
        public Text buttonText;

        private GridViewModel _gridViewModel;

        public buttonView(GridViewModel gridViewModel)
        {
            _gridViewModel = gridViewModel;
        }
        
        public void SetState(TurnsState state)
        {
            if (state == TurnsState.X)
            {
                buttonText.text = "X";
            }
            else
            {
                buttonText.text = "O";
            }
        }
        
        // public void SetSpace()
        // {
        //     buttonText.text = gameController.GetPlayerSide();
        //     button.interactable = false;
        //     gameController.EndTurn();
        // }
        
        public void Initialize()
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => _gridViewModel.SetState(this));
        }

        public void CleanData()
        {
            throw new System.NotImplementedException();
        }
    }
}