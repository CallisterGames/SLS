# SLS
Save Load System

#How to use
- Access the SaveLoadManager instance any way you seem fit(eg. DI) and call Initialize();
- Use Save<[Your SaveData class]>() or SaveAll() to save data to the JSON.
- Use Load<[Your SaveData class]>() to load the required data.
- Sanity check before loading, use HasSave<[Your SaveData class]>() before loading to avoid errors
# How to create Custom Data
- Create a script and derive from SaveData, the SLS will pick up on it.
