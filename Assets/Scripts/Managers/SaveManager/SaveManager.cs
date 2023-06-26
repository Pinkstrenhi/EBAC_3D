using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Collectables;
using UnityEngine;
using NaughtyAttributes;
using Core.Singleton;
public class SaveManager : Singleton<SaveManager>
{
    private SaveSetup _saveSetup;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _saveSetup = new SaveSetup();
        _saveSetup.coins = 0;
        _saveSetup.health = 0;
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
            SaveItems();
            Save();
        }

        private void SaveFile(string json)
        {
            //string path = Application.persistentDataPath + "/save.txt";
            string path = Application.streamingAssetsPath + "/save.txt";
            
            /*string fileLoaded = "";
            if (File.Exists(path))
            {
                fileLoaded = File.ReadAllText(path);
                File.WriteAllText(path,json);
            }*/
            Debug.Log(path);
            File.WriteAllText(path,json);
        }

        public void SaveItems()
        {
            _saveSetup.coins = Collectables.CollectableManager.Instance.
                GetCollectableByType(Collectables.CollectablesType.Coin).soInt.value;
            _saveSetup.health = Collectables.CollectableManager.Instance.
                GetCollectableByType(Collectables.CollectablesType.LifePack).soInt.value;
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
    public int coins;
    public int health;
    public int lastLevel;
    public string playerName;
}

