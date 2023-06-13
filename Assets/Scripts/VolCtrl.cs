using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolCtrl : MonoBehaviour
{
    public void MuteToggle(bool unmuted)
    {
        if(unmuted)
        {
            AudioListener.volume = 1;
        }
        else{
            AudioListener.volume = 0;
        }
    }
}
