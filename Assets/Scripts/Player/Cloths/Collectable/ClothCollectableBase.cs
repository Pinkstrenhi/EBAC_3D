using System;
using System.Collections;
using System.Collections.Generic;
using Cloth;
using UnityEngine;

namespace Cloth
{
    public class ClothCollectableBase : MonoBehaviour
    {
        public TypeCloth typeCloth;
        public string compareTag = "Player";
        public float duration = 2f;
        //public ClothBaseSO clothBaseSo;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(compareTag))
            {
                Collect();
            }
        }

        public virtual void Collect()
        {
            HideObject();
            var setup = ClothManager.Instance.GetSetupByType(typeCloth);
            Player.Instance.ChangeTexture(setup,duration);
            //ApplyPowerUpTexture(clothBaseSo,clothBaseSo.duration);
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        /*public static void ApplyPowerUpTexture(ClothSetup clothSetup,float duration)
        {
            Player.Instance.ChangeTexture(clothSetup,duration);
        }*/
    }
}
