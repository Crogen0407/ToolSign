using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConverter : MonoBehaviour
{
    public Vector3 CameraLookDirection { get; private set; }
    
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
    }
    
    void FixedUpdate()
    {
        if(CurrentCameraController != null)
            CurrentCameraController.CameraUpdate();
    }

    private void Update()
    {
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
