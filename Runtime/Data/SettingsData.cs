using UnityEngine;

namespace Game.SLS
{
    [System.Serializable]
    public class SettingsData : SaveData
    {
        public float AudioVolume = 0.5f;
        public ScreenOrientation ScreenOrientation = Screen.orientation;
        public float CameraSize = 3.77f;
    }
}
