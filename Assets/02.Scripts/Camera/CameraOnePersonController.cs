using System;
using System.Collections;
using System.Collections.Generic;
using Crogen.MathfExtension;
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
        
        Vector2 vec = _player.inputReader.MouseDeltaPosition;
        camera.transform.eulerAngles += new Vector3(
            -vec.y,
            vec.x,
            0) * (cameraConverter.onePersonCameraRotationSpeed * Time.deltaTime);

        Vector3 angles = camera.transform.eulerAngles;
        angles.x = Mathf.Clamp(MathfExtension.WrapAngle(angles.x), -45f, 45f);
        camera.transform.eulerAngles = angles;
    }

    public override void CameraFixedUpdate()
    {
        base.CameraFixedUpdate();
        
    }
}
