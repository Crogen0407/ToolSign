using System;
using System.Collections;
using System.Collections.Generic;
using Crogen.PowerfulInput;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _colliderCenter;
    [SerializeField] private LayerMask _layerMask;
    
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
        _rigidbody.velocity = new Vector3(
            CheckAroundCollider(_colliderCenter, new Vector3(vec.x, 0, 0), 1.2f, _layerMask),
            0, 
            CheckAroundCollider(_colliderCenter, new Vector3(0, 0, vec.z), 1.2f, _layerMask)) * _moveSpeed;
    }

    private int CheckAroundCollider(Vector3 center, Vector3 direction, float maxDistance, LayerMask layerMask)
    {
        center += transform.position;
        Debug.DrawRay(center, direction * maxDistance, Color.green, 0.1f);
        return Physics.Raycast(center, direction, maxDistance, layerMask) == true || direction == Vector3.zero ? 0 : 1;
    }

    void Update()
    {
        Move();
    }
}
