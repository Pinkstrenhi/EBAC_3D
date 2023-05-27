using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public float speedMovement = 25f;
    public float speedRotation = 300f;
    public float gravity = 9.8f;
    private float _speedVertical = 0f;
    private void Update()
    {
        transform.Rotate(0,Input.GetAxis("Horizontal") * speedRotation * Time.deltaTime,0);
        var verticalMovement = transform.forward * Input.GetAxis("Vertical") * speedMovement;
        _speedVertical -= gravity * Time.deltaTime;
        verticalMovement.y = _speedVertical;
        characterController.Move(verticalMovement * Time.deltaTime);
    }
}
