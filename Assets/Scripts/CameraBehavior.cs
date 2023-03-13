using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBehavior : CinemachineExtension
{
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(stage == CinemachineCore.Stage.Body) //if Cinemachine is positioning
        {
            Vector3 position = state.RawPosition; //get position
            position.x = 0; //set x to zero
            state.PositionCorrection = position; //reassign position
        }
    }
}
