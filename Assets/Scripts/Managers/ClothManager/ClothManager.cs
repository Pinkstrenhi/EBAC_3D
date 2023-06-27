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
}
