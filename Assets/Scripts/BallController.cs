using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CinemachineFreeLook look;
    //private bool camera = false;
    private void Update() {
        look.enabled = Input.GetMouseButton(0);
    }
}
