using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Gameobject array to get reference of all the Coins in the scene
    private GameObject[] coins;

    void Update()
    {
        // check if we are not in the menu
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            // find all the gameobjects with the tag "coin" then load the next scene when they are no more
            coins = GameObject.FindGameObjectsWithTag("Coin");
            if (coins.Length == 0)
            {
                if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //if it went through all the levels available, redirects to Menu (build index 0)
                else
                    SceneManager.LoadScene(0);

            }
        }
    }

    // Functions to load the levels based on the build index(Go to File->BuildSettings to manage it)

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

    public void GotoLevel6()
    {
        SceneManager.LoadScene(6);
    }
    public void GotoLevel7()
    {
        SceneManager.LoadScene(7);
    }
    public void GotoLevel8()
    {
        SceneManager.LoadScene(8);
    }
    public void GotoLevel9()
    {
        SceneManager.LoadScene(9);
    }
    public void GotoLevel10()
    {
        SceneManager.LoadScene(10);
    }
}
