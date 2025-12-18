using System.Collections.Generic;
using UnityEngine;

namespace Game.SLS 
{
    [System.Serializable]
    public class ResourcesData : SaveData
    {
        public Dictionary<string, int> Resources = new() {};

        public void AddResource(string resourceID, int amount)
        {
            if (Resources.ContainsKey(resourceID))
                Resources[resourceID] += amount;
            else
                Resources.Add(resourceID, amount);
        }

        public void RemoveResource(string resourceID, int amount)
        {
            if (Resources.ContainsKey(resourceID))
            {
                Resources[resourceID] -= amount;
                if (Resources[resourceID] <= 0)
                    Resources.Remove(resourceID);
            }
        }
    }
}
