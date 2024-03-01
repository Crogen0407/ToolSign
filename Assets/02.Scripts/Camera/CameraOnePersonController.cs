using System;
using System.Collections;
using System.Collections.Generic;
using Crogen.MathfExtension;
using UnityEngine;

public class CameraOnePersonController : CameraController
{
    public CameraOnePersonController(CameraConverter cameraConverter, Camera camera) : base(cameraConverter, camera)
    {
        cameraNumber = 1;
    }

    public override void CameraUpdate()
    {
        base.CameraUpdate();
        cameraTransform.position = _player.transform.position + cameraConverter.onePersonCameraPosition;
        
        ForwardVector = cameraTransform.forward;
        RightVector = cameraTransform.right;
        
        Vector2 vec = _player.inputReader.MouseDeltaPosition;
        cameraTransform.eulerAngles += new Vector3(
            -vec.y,
            vec.x,
            0) * (cameraConverter.onePersonCameraRotationSpeed * Time.deltaTime);

        Vector3 angles = cameraTransform.eulerAngles;
        angles.x = Mathf.Clamp(MathfExtension.WrapAngle(angles.x), -45f, 45f);
        cameraTransform.eulerAngles = angles;
    }
}
