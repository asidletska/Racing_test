using UnityEngine;
using System.IO;

public class SaveService : MonoBehaviour
{
    private string Path => Application.persistentDataPath + "/save.json";
    public SaveData Data;

    public SaveService()
    {
        Load();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(Path, json);
    }

    public void Load()
    {
        if (File.Exists(Path))
        {
            string json = File.ReadAllText(Path);
            Data = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Data = new SaveData();
            Save();
        }
    }
}
