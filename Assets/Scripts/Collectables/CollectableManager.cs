using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using NaughtyAttributes;

namespace Collectables
{
    public enum CollectablesType
    {
        Coin,
        LifePack
    }

    public class CollectableManager : Singleton<CollectableManager>
    {
        public List<CollectablesSetup> collectablesSetups;
        private void Start()
        {
            Reset();
        }

        private void Reset()
        {
            foreach (var i in collectablesSetups)
            {
                i.soInt.value = 0;
            }
        }

        public void AddByType(CollectablesType collectablesType,int amount = 1)
        {
            if (amount < 0)
            {
                return;
            }

            collectablesSetups.Find(i => i.collectablesType == 
                                         collectablesType).soInt.value += amount;
        }

        public void RemoveByType(CollectablesType collectablesType,int amount = 1)
        {
            if (amount > 0)
            {
                return;
            }
            var  collectable = collectablesSetups.Find(i => i.collectablesType == 
                                                            collectablesType);
            collectable.soInt.value += amount;
            if (collectable.soInt.value < 0)
            {
                collectable.soInt.value = 0;
            }
        }
        [Button]
        private void AddCoin()
        {
            AddByType(CollectablesType.Coin);
        }
        [Button]
        private void AddLifePack()
        {
            AddByType(CollectablesType.LifePack);
        }
    }

    [Serializable]
    public class CollectablesSetup
    {
        public CollectablesType collectablesType;
        public SO_Int soInt;
        public Sprite icon;
    }
}
