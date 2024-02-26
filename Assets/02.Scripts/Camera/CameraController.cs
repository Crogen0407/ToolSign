using UnityEngine;

public abstract class CameraController
{
    public Vector3 ForwardVector { get; protected set; }
    public Vector3 RightVector { get; protected set; }
    
    public CameraConverter cameraConverter;
    public Camera camera;
    public Transform cameraTransform;
    protected Player _player;
    
    public CameraController(CameraConverter cameraConverter, Camera camera)
    {
        this.cameraConverter = cameraConverter;
        _player = GameManager.Instance.Player;
        this.camera = camera;
        cameraTransform = camera.transform;
    }

    public virtual void CameraInit()
    {
        ForwardVector = Vector3.forward;
        RightVector = Vector3.right;
    }
    
    public virtual void CameraUpdate()
    {
        
    }
    
    public virtual void CameraFixedUpdate()
    {
        
    }
}
