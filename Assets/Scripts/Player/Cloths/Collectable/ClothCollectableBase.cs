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
            Player.Instance.clothChanger.ChangeTexture(setup);
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }
}
