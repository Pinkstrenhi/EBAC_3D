using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class SaveManager : MonoBehaviour
{
    [Button]
    private void Save()
    {
        SaveSetup saveSetup = new SaveSetup();
        saveSetup.lastLevel = 2;
        saveSetup.playerName = "player";
        var setupToJson = JsonUtility.ToJson(saveSetup,true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    private void SaveFile(string json)
    {
        string path = Application.persistentDataPath + "/save.txt";
        //string path = Application.streamingAssetsPath + "/save.txt";
        
        /*string fileLoaded = "";
        if (File.Exists(path))
        {
            fileLoaded = File.ReadAllText(path);
            File.WriteAllText(path,json);
        }*/
        Debug.Log(path);
        File.WriteAllText(path,json);
    }
}
[Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playerName;
}
