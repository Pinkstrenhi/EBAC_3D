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
    public int lastLevel;
    public Action<SaveSetup> fileLoadedAction;
    public float loadDelay = 0.1f;
    [SerializeField]private SaveSetup _saveSetup;
    private string _path = Application.streamingAssetsPath + "/save.txt";
    public SaveSetup SaveSetup
    {
        get
        {
            return _saveSetup;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Load();
        Invoke(nameof(Load),loadDelay);
    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.coins = 0;
        _saveSetup.health = 0;
        _saveSetup.lastLevel = 0;
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
            //string path = Application.streamingAssetsPath + "/save.txt";
            
            /*string fileLoaded = "";
            if (File.Exists(path))
            {
                fileLoaded = File.ReadAllText(path);
                File.WriteAllText(path,json);
            }*/
            Debug.Log(_path);
            File.WriteAllText(_path,json);
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

    #region Load

        [Button]
        private void Load()
        {
            var fileLoaded = "";
            if (File.Exists(_path))
            {
                fileLoaded = File.ReadAllText(_path);
                _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
                lastLevel = _saveSetup.lastLevel;
            }
            else
            {
                CreateNewSave();
                Save();
            }
            fileLoadedAction.Invoke(_saveSetup);
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

