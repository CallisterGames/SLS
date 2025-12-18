using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Game.SLS
{
    public class SaveDataRegistry
    {
        private Dictionary<System.Type, string> _saveDataRegistry = new Dictionary<System.Type, string>();

        public SaveDataRegistry()
        {
            _saveDataRegistry = new Dictionary<System.Type, string>()
            {
                { typeof(PlayerData), "PlayerData" },
            };

            var saveDataTypes = Assembly.GetExecutingAssembly().GetTypes().Where(c => c.IsClass && !c.IsAbstract && c.IsSubclassOf(typeof(SaveData)));

            foreach (var saveDataType in saveDataTypes)
            {
                _saveDataRegistry[saveDataType] = saveDataType.FullName;
            }
        }

        internal Dictionary<System.Type, string> GetSaveDataRegistry() => _saveDataRegistry;

        public string GetSaveKey<T>() where T : SaveData
        {
            return _saveDataRegistry.TryGetValue(typeof(T), out string key) ? key : null;
        }

        public string GetSaveKey(System.Type type)
        {
            return _saveDataRegistry.TryGetValue(type, out string key) ? key : null;
        }
    }
}
