using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class SavableObject : MonoBehaviour
{
    public string saveType;
    [HideInInspector]public int id;
    [HideInInspector] public Vector3 pos, rot;


    public virtual void SaveObjectData()
    {
        pos = transform.position;
        rot = transform.rotation.eulerAngles;
        id = gameObject.GetInstanceID();
        SaveLoadManager.instance.CollectSaveInfo(this);
    }

    public virtual void LoadObjectData(string jsonedData)
    {
    }

    public virtual void LookForObjectDataInSavefile()
    {
        foreach(string jsonedData in SaveLoadManager.instance.saveFile)
        {
            SavableObject savedObj = JsonConvert.DeserializeObject<SavableObject>(jsonedData);
            if (savedObj.id == gameObject.GetInstanceID() && (saveType == savedObj.saveType))
            {
                LoadObjectData(jsonedData);
            }
        }
    }
}
