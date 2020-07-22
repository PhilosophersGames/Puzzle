using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    private GameObject[] coins;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            coins = GameObject.FindGameObjectsWithTag("Coin");
            if (coins.Length == 0)
            {
                if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void GotoLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void GotoLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void GotoLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void GotoLevel4()
    {
        SceneManager.LoadScene(4);
    }
    public void GotoLevel5()
    {
        SceneManager.LoadScene(5);
    }
}
