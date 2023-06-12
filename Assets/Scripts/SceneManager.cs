using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour
{
    public void MainMenu()
    {
        BallController.temp = 0;
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        BallController.temp -= BallController.kuranginPukul;
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Map1()
    {
        SceneManager.LoadScene("Map");
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
    public void Map2Lv1()
    {
        SceneManager.LoadScene("MapB1");
    }
    public void Map2Lv2()
    {
        SceneManager.LoadScene("MapB2");
    }
    public void Map2Lv3()
    {
        SceneManager.LoadScene("MapB3");
    }
    public void Map2Lv4()
    {
        SceneManager.LoadScene("MapB4");
    }
    public void Map3Lv1()
    {
        SceneManager.LoadScene("MapC1");
    }
    public void Map3Lv2()
    {
        SceneManager.LoadScene("MapC2");
    }
    public void Map3Lv3()
    {
        SceneManager.LoadScene("MapC3");
    }
    public void Map3Lv4()
    {
        SceneManager.LoadScene("MapC4");
    }
    public void ExitGame() {
     Application.Quit();
    }
    // Start is called before the first frame update
}
