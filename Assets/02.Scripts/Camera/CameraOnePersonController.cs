using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnePersonController : CameraController
{
    public CameraOnePersonController(CameraConverter cameraConverter, Camera camera) : base(cameraConverter, camera)
    {
    }

    public override void CameraUpdate()
    {
        base.CameraUpdate();
        camera.transform.position = _player.transform.position;
    }
}
