using UnityEngine;
using UnityEngine.UI;

namespace MVVM_Chudakov
{
    public class buttonView: MonoBehaviour, IInitialize,ICleanData
    {
        public Button button;
        [SerializeField]
        public Text buttonText;
        
        // как я понимаю в въюшке мы храним состояние
        public TurnsState CurrentState { get; set; }
        private int number;
        
        private GridViewModel _gridViewModel;

        public void addModel(GridViewModel gridViewModel, int numberInList)
        {
            _gridViewModel = gridViewModel;
            number = numberInList;
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

        public void SetZero()
        {
            buttonText.text = "";
        }
        public void Initialize()
        {
            CleanData();
            button.onClick.AddListener(() => _gridViewModel.SetState(this,number));
        }

        public void CleanData()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}