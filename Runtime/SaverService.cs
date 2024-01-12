using System.Collections.Generic;
using LittleBit.Modules.CoreModule;
using UnityEngine.Scripting;

namespace ugames.Modules.SaveModule
{
    public class SaverService : ISaverService
    {
        private readonly List<ISavable> _savables;
        
        [Preserve]
        public SaverService(ILifecycle lifecycle)
        {
            _savables = new List<ISavable>();
            /*lifecycle.onApplicationFocus += OnApplicationFocus;
            lifecycle.onApplicationQuit += OnApplicationQuit;*/
            
        }
        public void AddSavableObject(ISavable savableObject)
        {
            if (!_savables.Contains(savableObject))
            {
                _savables.Add(savableObject);
            }
        }
        public void RemoveSavableObject(ISavable savableObject)
        {
            _savables.Remove(savableObject);
        }
        
        private void SaveData()
        {
            foreach (var savable in _savables)
            {
                savable.Save();
            }
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                SaveData();
            }
        }
        
        private void OnApplicationQuit()
        {
            SaveData();
        }

    }
}