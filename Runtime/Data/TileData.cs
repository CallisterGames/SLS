using System.Collections.Generic;
using UnityEngine;

namespace Game.SLS
{
    [System.Serializable]
    public class TileData : SaveData
    {
        public List<string> UnlockedTilesIDs = new List<string>() { };
    }
}
