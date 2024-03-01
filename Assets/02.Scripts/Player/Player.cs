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
        CameraController currentCameraController = cameraConverter.CurrentCameraController;
        Vector3 vec = new Vector3(currentCameraController.ForwardVector.x, 0, currentCameraController.ForwardVector.z).normalized;
        vec = (currentCameraController.ForwardVector * inputReader.InputVector.z) + (currentCameraController.RightVector * inputReader.InputVector.x);

        Vector3 convertVector = Vector3.zero;
     
        convertVector = new Vector3(
            CheckAroundCollider(_colliderCenter, new Vector3(vec.x, 0, 0), vec.x * 0.1f, _layerMask).x,
            0, 
            CheckAroundCollider(_colliderCenter, new Vector3(0, 0, vec.z), vec.z * 0.1f, _layerMask).z).normalized * _moveSpeed;
        _rigidbody.velocity = convertVector;
    }

    private Vector3 CheckAroundCollider(Vector3 center, Vector3 direction, float maxDistance, LayerMask layerMask)
    {
        center += transform.position;
        if (maxDistance != 0)
        {
            if (Physics.BoxCast(center, transform.lossyScale/2, direction, Quaternion.identity, 0.1f, layerMask))
            {
                return Vector3.zero;
            }
            
            return direction * Mathf.Pow(Mathf.Sign(maxDistance), 2);
        }

        return Vector3.zero;
    }

    void Update()
    {
        Move();
    }
}
