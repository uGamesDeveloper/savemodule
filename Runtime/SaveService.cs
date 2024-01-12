using LittleBit.Modules.CoreModule;
using UnityEngine.Scripting;

namespace ugames.Modules.SaveModule
{
    public class SaveService : ISaveService
    {
        private IDataSaver _dataSaver;
        
        [Preserve]
        public SaveService(IDataSaver dataSaver)
        {
            _dataSaver = dataSaver;
        }
        
        public void SaveData(string key, object data)
        {
            _dataSaver.SaveData(key, data);
        }

        public T LoadData<T>(string key) where T : Data
        {
            return _dataSaver.LoadData<T>(key);
        }

        public void ClearData(string key)
        {
            _dataSaver.ClearData(key);
        }
    }
}