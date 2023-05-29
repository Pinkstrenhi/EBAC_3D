using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
   public GunBase gunBase;
   public Transform gunPosition;
   private GunBase _currentGunBase;
   protected override void Init()
   {
      base.Init();
      CreateGun();
      inputs.Gameplay.Shoot.performed += context => StartShoot();
      inputs.Gameplay.Shoot.canceled += context => CancelShoot();
   }
   private void CreateGun()
   {
      _currentGunBase = Instantiate(gunBase,gunPosition);
      //_currentGunBase.transform.localPosition = _currentGunBase.transform.localEulerAngles = Vector3.zero;
      _currentGunBase.transform.localPosition = Vector3.zero;
      _currentGunBase.transform.localEulerAngles = Vector3.zero;
   }
   private void StartShoot()
   {
      _currentGunBase.StartShoot();
      Debug.Log("StartShoot");
   }
   private void CancelShoot()
   {
      _currentGunBase.StopShoot();
      Debug.Log("CancelShoot");
   }
}
