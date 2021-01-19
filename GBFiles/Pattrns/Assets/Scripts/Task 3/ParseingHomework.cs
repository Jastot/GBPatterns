using UnityEngine;

namespace Asteroids.Task_3
{
    public class ParseingHomework: MonoBehaviour
    {
        private string _path = @"C:\Users\Геориг\Desktop\GBPatterns\GBPatterns\GBFiles\Pattrns\Assets\Scripts\Task 3\Task3JSON.json"; 

        
        public ParseingHomework()
        {
            var JSONDataCollector = new JSONDataCollector().LoadFile(_path);
            
            //InfoFromJson enemies = new InfoFromJson();
            /*unit[] units = new unit[5];
            units[0] = new unit()
            {
                type = "mage",
                health = 50
            };
            units[1] = new unit()
            {
                type = "mage",
                health = 50
            };
            // units[1].type = "mage";
            // units[1].health = 50;
            Debug.Log(units[0].health);
            Debug.Log(units[0].type);
            // Debug.Log(units[1].health);
            // Debug.Log(units[1].type);
           // enemies.EnemyPools[0].unit = unit;
           foreach (var unit in units)
           {
             string playerToJson = JsonUtility.ToJson(unit);
             Debug.Log(playerToJson);   
           }*/
                       
            
            var MainFactory = new MainFactory(JSONDataCollector);
            MainFactory.Create();
        }
    }
}