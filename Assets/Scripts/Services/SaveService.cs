using UnityEngine;
using System.IO;

public class SaveService : MonoBehaviour
{
    private string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    public SaveData Data { get; private set; }

    private void Awake()
    {
        Load();
    }

    public void Save()
    {
        if (Data == null) Data = new SaveData();

        string json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(SavePath, json);
    }

    public void Load()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            Data = JsonUtility.FromJson<SaveData>(json);
        }

        if (Data == null)
            Data = new SaveData();
    }
}
