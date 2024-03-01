using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConverter : MonoBehaviour
{
    public Vector3 onePersonCameraPosition;
    
    public float onePersonCameraRotationSpeed = 5;
    public float thirdPersonCameraRotationSpeed = 5;
    
    //CameraControllers
    private CameraThirdPersonController _cameraThirdPersonController;
    public CameraOnePersonController _cameraOnePersonController;
    public CameraController CurrentCameraController { get; private set; }
    
    //Camera
    public Camera[] cameras;
    
    void Awake()
    {
        _cameraThirdPersonController = new CameraThirdPersonController(this, cameras[0]);
        _cameraOnePersonController = new CameraOnePersonController(this, cameras[1]);
        ChangeCurrentCamera(_cameraThirdPersonController);
    }

    public void ChangeCurrentCamera(CameraController cameraController)
    {
        CurrentCameraController = cameraController;
        
        for (int i = 0; i < cameras.Length; i++)
            cameras[i].gameObject.SetActive(false);
        
        CurrentCameraController.camera.gameObject.SetActive(true);
        cameraController.CameraInit();
    }
    
    void FixedUpdate()
    {
        if(CurrentCameraController != null)
            CurrentCameraController.CameraFixedUpdate();
    }

    private void Update()
    {
        if(CurrentCameraController != null)
            CurrentCameraController.CameraUpdate();
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ChangeCurrentCamera(_cameraThirdPersonController);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCurrentCamera(_cameraOnePersonController);
        }
    }
}
