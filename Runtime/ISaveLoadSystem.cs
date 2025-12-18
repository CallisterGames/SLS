namespace Game.SLS
{
    public interface ISaveLoadSystem
    {
        public void SaveAll();
        public void Save<T>() where T : SaveData;
        public T Load<T>() where T : SaveData, new();
        public bool HasSave<T>() where T : SaveData;
    }
}