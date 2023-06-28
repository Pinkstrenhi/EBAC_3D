using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

namespace Cloth
{
    public enum TypeCloth
    {
        ClothBasic,
        ClothSpeed,
        ClothStrength,
        ClothColor
    }
    public class ClothManager : Singleton<ClothManager>
    {
        public List<ClothSetup> clothSetups;
        public Texture2D texture2DLast;
        public TypeCloth typeClothLast;
        //private ClothBaseSO _clothBaseSo;
        private void Start()
        {
            ClothLoad();
        }

        public ClothSetup GetSetupByType(TypeCloth typeCloth)
        {
            return clothSetups.Find(i => i.typeCloth == typeCloth);
        }
        public void SaveCloth(Texture2D texture2D)
        {
            texture2DLast = texture2D;
            SaveManager.Instance.SaveCloth(texture2DLast);
        }
        /*public void SaveCloth(ClothBaseSO clothBaseSo)
        {
            _clothBaseSo = clothBaseSo;
        }*/
        public void ClothLoad()
        {
            var clothTexture = SaveManager.Instance.SaveSetup.texture2D;
            if (clothTexture != null)
            {
                bool textureFound = false;
                for (int i = 0; i < clothSetups.Count; i++)
                {
                    if (clothSetups[i].texture2D == clothTexture)
                    {
                        texture2DLast = clothTexture;
                        Player.Instance.transform.GetComponent<ClothChanger>().texture2D = clothTexture;
                        textureFound = true;
                        break;
                    }
                }
            }
        }
    }
    [Serializable]
    public class ClothSetup
    {
        public TypeCloth typeCloth;
        public Texture2D texture2D;
    }

    /*[Serializable]
    public class ClothBaseData
    {
        public TypeCloth typeCloth;
        public float duration;
    }
    [Serializable]
    public class ClothStrengthData : ClothBaseData
    {
        public float damageMultiply;
    }
    public ClothBaseData ConvertClothData(ClothBaseSO clothBaseSo)
    {
        ClothBaseData converted = null;
        bool error = false;
        if (clothBaseSo is ClothStrengthSO)
        {
            converted = new ClothStrengthData();
            ((ClothStrengthData)converted).damageMultiply = ((ClothStrengthSO)clothBaseSo).damageMultiply;
        }
        else
        {
            error = true;
        }

        if (!error)
        {
            converted.duration = clothBaseSo.duration;
            converted.typeCloth = clothBaseSo.typeCloth;
        }

        return converted;
    }*/
}
