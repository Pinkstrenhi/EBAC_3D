using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
   public GunBase gunBase;
   protected override void Init()
   {
      base.Init();
      inputs.Gameplay.Shoot.performed += context => StartShoot();
      inputs.Gameplay.Shoot.canceled += context => CancelShoot();
   }
   private void StartShoot()
   {
      gunBase.StartShoot();
      Debug.Log("StartShoot");
   }
   private void CancelShoot()
   {
      gunBase.StopShoot();
      Debug.Log("CancelShoot");
   }
}
