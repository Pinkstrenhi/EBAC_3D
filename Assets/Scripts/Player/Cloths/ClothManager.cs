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

        public ClothSetup GetSetupByType(TypeCloth typeCloth)
        {
            return clothSetups.Find(i => i.typeCloth == typeCloth);
        }
    }
    [Serializable]
    public class ClothSetup
    {
        public TypeCloth typeCloth;
        public Texture2D texture2D;
    }
}
