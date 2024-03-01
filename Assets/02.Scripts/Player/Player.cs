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

        float X = !Mathf.Approximately(vec.x, 0f) ? Mathf.Sign(vec.x) : 0f;
        float Z = !Mathf.Approximately(vec.z, 0f) ? Mathf.Sign(vec.z) : 0f;
        
        _rigidbody.velocity = new Vector3(
            CheckAroundCollider(_colliderCenter, new Vector3(X, 0, 0), X * 0.1f, _layerMask),
            0, 
            CheckAroundCollider(_colliderCenter, new Vector3(0, 0, Z), Z * 0.1f, _layerMask)).normalized * _moveSpeed;
        
        //Debug.Log($"{CheckAroundCollider(_colliderCenter, new Vector3(vec.x, 0, 0), (int)Mathf.Clamp(vec.x, -1, 1) * 1.2f, _layerMask)} {CheckAroundCollider(_colliderCenter, new Vector3(0, 0, vec.z),  (int)Mathf.Clamp(vec.z, -1, 1) * 1.2f, _layerMask)}");
    }

    private float CheckAroundCollider(Vector3 center, Vector3 direction, float maxDistance, LayerMask layerMask)
    {
        center += transform.position;
        if (maxDistance != 0)
        {
            if (Physics.BoxCast(center, transform.lossyScale/2, direction, Quaternion.identity, 0.1f, layerMask))
            {
                return 0;
            }
            
            return Mathf.Sign(maxDistance);
        }

        return 0;
    }

    void Update()
    {
        Move();
    }
}
