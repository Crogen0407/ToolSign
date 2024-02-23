using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConverter : MonoBehaviour
{
    public Vector3 CameraLookDirection { get; private set; }
    
    //CameraControllers
    public CameraThirdPersonController CameraThirdPersonController { get; private set; }
    public CameraOnePersonController CameraOnePersonController { get; private set; }
    
    void Awake()
    {
        CameraThirdPersonController = new CameraThirdPersonController();
        CameraOnePersonController = new CameraOnePersonController();
    }

    void Update()
    {
        
    }
}
