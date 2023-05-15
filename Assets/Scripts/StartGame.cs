using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public float timeLeft = 3.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 


    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
            return;
        }
        Destroy(startText);
    }
}
