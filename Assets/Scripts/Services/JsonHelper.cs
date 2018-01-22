using System.IO;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class JsonHelper
    {
        public static T[] GetJsonArray<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.array;
        }
        
        public static string ArrayToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T> {array = array};
            return JsonUtility.ToJson(wrapper);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }

        public static string LoadJson(string filepath)
        {
            return File.ReadAllText(filepath);
        }

        public static void SaveJson(string filepath, string jsonString)
        {
            File.WriteAllText(filepath, jsonString);
        }
    }
}
