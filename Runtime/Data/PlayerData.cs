namespace Game.SLS
{
    [System.Serializable]
    public class PlayerData : SaveData
    {
        public int Experience = 0;
        public int CurrentLevel = 1;
        public float ElapsedTime = 0;
        public int DeadEnemies = 0;
        public bool TutorialPassed;
    }
}