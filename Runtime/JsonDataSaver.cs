using UnityEngine;
using UnityEngine.Scripting;

namespace ugames.Modules.SaveModule
{
    
    public class JsonDataSaver : IDataSaver
    {
        [Preserve]
        public JsonDataSaver()
        {
            
        }
        
        public void SaveData(string key, object data)
        {
            var jsonData = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, jsonData);
        }

        public void ClearData(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public T LoadData<T>(string key)
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }
    }
}