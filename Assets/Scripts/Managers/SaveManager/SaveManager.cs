using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Core.Singleton;
public class SaveManager : Singleton<SaveManager>
{
    private SaveSetup _saveSetup;
    protected override void Awake()
    {
        base.Awake();
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 2;
        _saveSetup.playerName = "player";
    }

    #region Save
        [Button]
        private void Save()
        {
            var setupToJson = JsonUtility.ToJson(_saveSetup,true);
            Debug.Log(setupToJson);
            SaveFile(setupToJson);
        }
        public void SaveName(string text)
        {
            _saveSetup.playerName = text;
            Save();
        }
        public void SaveLastLevel(int level)
        {
            _saveSetup.lastLevel = level;
            Save();
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
        [Button]
        private void SaveLevelOne()
        {
            SaveLastLevel(1);
        } 
        [Button]
        private void SaveLevelFive()
        {
            SaveLastLevel(5);
        }
    #endregion
}
[Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playerName;
}

