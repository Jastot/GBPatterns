using System.Collections.Generic;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class ChainController: IInitialization
    {
        private List<GameHandler> _gameHandlers;
        
        public ChainController(List<GameHandler> gameHandlers)
        {
            _gameHandlers = gameHandlers;
        }
        
       
        public void Initialization()
        {
            _gameHandlers[0].Handle();
            for (var i = 1; i < _gameHandlers.Count; i++)
            {
                _gameHandlers[i - 1].SetNext(_gameHandlers[i]);
            }
        }
        
    }
}