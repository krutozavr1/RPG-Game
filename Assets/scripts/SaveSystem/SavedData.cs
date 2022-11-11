using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData 
{
    public string jsonedData;
    public SavableObject instance;

    public SavedData(SavableObject obj, string json)
    {
        instance = obj;
        jsonedData = json;
    }
}
