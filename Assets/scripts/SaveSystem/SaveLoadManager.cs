using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;
    string path, pathToBaseSafe;
    List<SavableObject> savedObjects = new List<SavableObject>();
    List<string>jsonedData = new List<string>();
    string jsonFile;

    public List<string> saveFile 
    {
        get
        {
            return jsonedData;
        }
    }


    void Start()
    {
        instance = this;
        path = Application.persistentDataPath + "/dataSaveFile.txt";
        pathToBaseSafe = Application.persistentDataPath + "/baseSave.txt";

    }

    void Update()
    {
        if(Keyboard.current.nKey.wasReleasedThisFrame)
        {
            SaveGame();
        }
        if(Keyboard.current.lKey.wasReleasedThisFrame)
        {
            LoadGame();
        }

    }

    public void SaveGame()
    {
        FindSavableObjects();
        SerializeGameData();
    }

    private void FindSavableObjects()
    {
        savedObjects.Clear();
        jsonedData.Clear();
        foreach (SavableObject obj in FindObjectsOfType<SavableObject>(true))
        {
            obj.SaveObjectData();
        }
    }

    private void SerializeGameData()
    {
        jsonFile = JsonConvert.SerializeObject(jsonedData, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        File.WriteAllText(path, jsonFile);

    }
    public void LoadGame(bool loadBaseSave = false)
    {
        string pathToFile = path;
        if(loadBaseSave)
        {
            pathToFile = pathToBaseSafe;
        }
        DeserealizeGameData(pathToFile);
        foreach(SavableObject obj in FindObjectsOfType<SavableObject>(true))
        {
            obj.LookForObjectDataInSavefile();
        }
    }

    public void DeserealizeGameData(string pathToFile)
    {
        jsonedData = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(pathToFile));

    }


    public void CollectSaveInfo(SavableObject obj)
    {
        jsonedData.Add(JsonUtility.ToJson(obj, true));
    }
}
