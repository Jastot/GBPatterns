using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PatternsChudakovGA
{
    public class UIController: IExecute, IInitialization
    {
        //чет перегруженный класс вышел...
        //но он ничего не делает толком........
        //подписывается и выводит данные...
        //хз на что еще можно разбить...
        //да и я бы сделал иначе,но надо удовлетворить заданию...
        private readonly GameObject _info;
        private readonly GameObject _health;
        private readonly GameObject _damage;
        private readonly List<AsteroidProvider> _getEnemies;
        private readonly GameContext _gameContext;
        private readonly int _getInstanceID;
        private TextPanel _infoTextPanel;
        private TextPanel _healthTextPanel;
        private TextPanel _damageTextPanel;
        private readonly Stack<UIType> _stateUi = new Stack<UIType>();
        private BaseUI _currentWindow;
        
        public UIController(GameObject info, GameObject health, GameObject damage,
            List<AsteroidProvider> getEnemies,GameContext gameContext,
            int getInstanceID)
        {
            _info = info;
            _health = health;
            _damage = damage;
            _getEnemies = getEnemies;
            _gameContext = gameContext;
            _getInstanceID = getInstanceID;
            _infoTextPanel = new TextPanel(_info);
            _healthTextPanel=new TextPanel(_health);
            _damageTextPanel = new TextPanel(_damage);
            _damageTextPanel.Cancel();
            _healthTextPanel.Cancel();
            _infoTextPanel.Cancel();
        }

        private void Show(UIType uiType, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }
            switch (uiType)
            {
                case UIType.Info:
                    _currentWindow = _infoTextPanel;
                    break;
                case UIType.Health:
                    _currentWindow =_healthTextPanel;
                    break;
                case UIType.Damage:
                    _currentWindow = _damageTextPanel;
                    break;
                default:
                    break;
            }
            _currentWindow.Execute();
            if (isSave)
            {
                _stateUi.Push(uiType);
            }
        }
        public void Execute(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Show(UIType.Info);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Show(UIType.Health);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_stateUi.Count > 0)
                {
                    Show(_stateUi.Pop(), false);
                }
            }

        }

        public void Initialization()
        {
            foreach (var enemy in _getEnemies)
            {
                enemy.OnTriggerEnterChange += EnemyOnOnTriggerEnterChange;
            }

            _gameContext.PlayerModel.PlayerStruct.LookAtHealth += PlayersHealth;
            _healthTextPanel.AddInfo("Health: "+ToKAndMore(_gameContext.PlayerModel.PlayerStruct.Health),false);
        }

        private void PlayersHealth(float health, int id)
        {
            _healthTextPanel.AddInfo("Health: "+ToKAndMore(health),false);
        }
        private string ToKAndMore(float number)
        {
            if (number > 999999999) throw new
                ArgumentOutOfRangeException(nameof(number),
                    "insert value betwheen 1 and 999999999");
            if (number < 1000) return Convert.ToString(number);
            if (number >= 1000 || number <= 9999) return Convert.ToString(number).Substring(0, 1) + "K";
            if (number >= 10000 || number <= 99999) return Convert.ToString(number).Substring(0, 2) + "K";
            if (number >= 100000 || number <= 999999) return Convert.ToString(number).Substring(0, 3) + "K";
            if (number >= 1000000 || number <= 999999) return Convert.ToString(number).Substring(0, 1) + "M";
            if (number >= 10000000 || number <= 9999999) return Convert.ToString(number).Substring(0, 2) + "M";
            if (number >= 100000000 || number <= 99999999) return Convert.ToString(number).Substring(0, 3) + "M";
            if (number >= 1000000000 || number <= 999999999) return Convert.ToString(number).Substring(0, 1) + "B";
            throw new ArgumentOutOfRangeException(nameof(number));
        }
        private void EnemyOnOnTriggerEnterChange(int whatStackIn, int inWhatStackIn)
        {
            if (whatStackIn == _getInstanceID)
            {
                _damageTextPanel.AddInfo("Asteroids health:" 
                                         +ToKAndMore(_gameContext.AsteroidModels[inWhatStackIn].AsteroidStruct.Strenght),false);
                _healthTextPanel.AddInfo("Health: "
                                         +ToKAndMore(_gameContext.PlayerModel.PlayerStruct.Health),false);
                _infoTextPanel.AddInfo($"Asteroid {_gameContext.AsteroidModels[inWhatStackIn].AsteroidStruct.Asteroid.name} " +
                     "take damage from Player: " +
                     $"{_gameContext.PlayerModel.PlayerStruct.CollisionDamage}", 
                    true);
                    
            }
            foreach (var key in _gameContext.BulletModels)
            { 
                if (whatStackIn == key.Key)
                {
                    _damageTextPanel.AddInfo("Asteroids health:" 
                                             +ToKAndMore(_gameContext.AsteroidModels[inWhatStackIn].AsteroidStruct.Strenght),false);
                    _infoTextPanel.AddInfo($"Asteroid {_gameContext.AsteroidModels[inWhatStackIn].AsteroidStruct.Asteroid.name} " +
                             "take damage from " +
                             $"{_gameContext.BulletModels[whatStackIn].BulletStruct.Bullet.name}: " +
                             $"{ToKAndMore(_gameContext.BulletModels[whatStackIn].BulletStruct.CurrentDamage)}", 
                        true);

                }  
            }
        }
    }
}