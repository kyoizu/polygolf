using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour
{
    public void Map1()
    {
        SceneManager.LoadScene("Map");
    }

    public void MainMenu()
    {
        BallController.temp = 0;
        SceneManager.LoadScene("MainMenu");
    }
    public void Map1Lv2()
    {
        SceneManager.LoadScene("Map1");
    }
    public void Map1Lv3()
    {
        SceneManager.LoadScene("Map2");
    }
    public void Map1Lv4()
    {
        SceneManager.LoadScene("Map3");
    }
    // Start is called before the first frame update
}
