using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothCollectableStrength : ClothCollectableBase
    {
        public float damageMultiply = 0.5f;

        public override void Collect()
        {
            base.Collect();
            //ClothStrengthSO clothStrengthSo = (ClothStrengthSO)clothBaseSO;
            //ApplyPowerUp(clothStrengthSo.damageMultiply,clothStrengthSo.duration);
            Player.Instance.healthBase.ChangeDamageMultiply(damageMultiply, duration);
        }
        /*public static void ApplyPowerUp(float damageMultiply,float duration)
        {
            Player.Instance.healthBase.ChangeDamageMultiply(damageMultiply, duration);
        }*/
    }
}
