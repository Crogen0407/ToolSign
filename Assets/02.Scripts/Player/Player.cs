using System;
using System.Collections;
using System.Collections.Generic;
using Crogen.PowerfulInput;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public InputReader inputReader;

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
        _rigidbody.velocity = inputReader.InputVector * _moveSpeed;
    }
    
    void Update()
    {
        Move();
    }
}
