using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;


namespace Asteroids.Task_3
{
    public class MainFactory: IFactory
    {
        private  List<IFactory> _listOfFactories;


        public MainFactory(string JSONFile)
        {
            _listOfFactories = new List<IFactory>();
            Debug.Log(JSONFile);
            unit[] enemies = JsonHelper.FromJson<unit>(JSONFile);

             foreach (var enemy in enemies)
             {
                 switch (enemy.type)
                 {
                     case "mage":
                         MageFactory mage = new MageFactory(enemy.type,enemy.health);
                         CreateFactory(mage);
                         break;
                     case "infantry":
                         IfantryFactory ifantry = new IfantryFactory(enemy.type,enemy.health);
                         CreateFactory(ifantry);
                         break;
                     
                 }
                 
             }
        }
        
        public void Create()
        {
            foreach (var factory in _listOfFactories)
            {
                factory.Create();
            }
        }

        private void CreateFactory(IFactory factory)
        {
            _listOfFactories.Add(factory);
        }
    }
}