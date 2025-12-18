using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.SLS
{
    public class SaveLoadSystem : ISaveLoadSystem
    {
        private readonly string _savePath = Application.persistentDataPath;
        private readonly Dictionary<Type, SaveData> _saveDataInstances = new();
        private SaveDataRegistry _saveDataRegistry;

        public void Initialize()
        {
            _saveDataRegistry = new SaveDataRegistry();
        }

        public void Save<T>() where T : SaveData
        {
            Type type = typeof(T);

            if (!_saveDataInstances.TryGetValue(type, out SaveData instance))
            {
                return;
            }

            string key = _saveDataRegistry.GetSaveKey<T>();
            string fullPath = Path.Combine(_savePath, key + ".json");

            try
            {
                string json = JsonConvert.SerializeObject(instance, Formatting.Indented);
                File.WriteAllText(fullPath, json);
            }
            catch (Exception e)
            {
               Debug.LogError($"Failed to save {typeof(T).Name}: {e.Message}");
            }
        }

        public T Load<T>() where T : SaveData, new()
        {
            Type type = typeof(T);

            if (_saveDataInstances.TryGetValue(type, out SaveData existingInstance))
            {
                return (T)existingInstance;
            }

            string key = _saveDataRegistry.GetSaveKey<T>();
            string fullPath = Path.Combine(_savePath, key + ".json");

            if (File.Exists(fullPath))
            {
                try
                {
                    string json = File.ReadAllText(fullPath);
                    T loadedInstance = JsonConvert.DeserializeObject<T>(json);
                    _saveDataInstances[type] = loadedInstance;
                    return loadedInstance;
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to load {typeof(T).Name}: {e.Message}");
                }
            }

            T newInstance = new T();
            _saveDataInstances[type] = newInstance;
            return newInstance;
        }

        public void SaveAll()
        {
            foreach (var saveInstance in _saveDataInstances)
            {
                string key = _saveDataRegistry.GetSaveKey(saveInstance.Key);

                if (key == null)
                {
                    Debug.LogError("No save key found for " + saveInstance.Key);
                    continue;
                }

                string json = JsonUtility.ToJson(saveInstance.Value, true);
                string fullPath = Path.Combine(_savePath, key + ".json");

                try
                {
                    File.WriteAllText(fullPath, json);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to save {saveInstance.Key.Name}: {e.Message}");
                }
            }
        }

        public bool HasSave<T>() where T : SaveData
        {
            string key = _saveDataRegistry.GetSaveKey<T>();
            return File.Exists(Path.Combine(_savePath, key + ".json"));
        }
    }
}