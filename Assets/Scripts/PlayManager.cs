using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] BallController ballCtrl;
    [SerializeField] CameraController camCtrl;

    private void Update() 
    {
        var inputActive = Input.GetMouseButton(0) && ballCtrl.IsMove() == false;
        if(ballCtrl.ShootingMode == false)
        {
            camCtrl.SetInputActive(inputActive);
        }
    }
}
