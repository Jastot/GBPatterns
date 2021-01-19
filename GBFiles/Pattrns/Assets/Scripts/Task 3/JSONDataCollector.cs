using System.IO;
using UnityEngine;

namespace Asteroids.Task_3
{
    public class JSONDataCollector
    {
        private string JSONFileStr;


        public string LoadFile(string path)
        {

            JSONFileStr = File.ReadAllText(path);
            string _jsonFile = JSONFileStr.Replace("unit","")
                .Replace(@""""":","").Replace(@"}, {",",").Replace(@"[{","[")
                .Replace(@"}]","]");
            _jsonFile = "{\"Units\":" + _jsonFile + "}";
            return _jsonFile; 
        }
    }
}