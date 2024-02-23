using UnityEngine;

public abstract class CameraController
{
    public CameraConverter cameraConverter;
    public Camera camera;
    protected Player _player;
    
    public CameraController(CameraConverter cameraConverter, Camera camera)
    {
        this.cameraConverter = cameraConverter;
        _player = GameManager.Instance.Player;
        this.camera = camera;
    }

    public virtual void CameraUpdate()
    {
        
    }
}
