using System;
using System.Collections;
using System.Collections.Generic;
using Crogen.PowerfulInput;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InputReader inputReader;
    public CameraConverter cameraConverter;
    [SerializeField] private float _moveSpeed = 5;
    
    #region Components

    private Rigidbody _rigidbody;

    #endregion    
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Move()
    {
        Vector3 vec = new Vector3(cameraConverter.CurrentCameraController.ForwardVector.x, 0, cameraConverter.CurrentCameraController.ForwardVector.z).normalized;
        vec = (vec * inputReader.InputVector.z) + (cameraConverter.CurrentCameraController.RightVector * inputReader.InputVector.x);
        _rigidbody.velocity = vec * _moveSpeed;
    }
    
    void Update()
    {
        Move();
    }
}
