using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Gameobject array to get reference of all the Coins in the scene
    private GameObject[] coins;
    public bool[] Unlocklevel;
    public int you;

    void Awake()
    {
        Unlocklevel = new bool[SceneManager.sceneCountInBuildSettings - 1];
        LoadUnlockedLevel();
    }

    void Update()
    {
        // check if we are not in the menu
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            // find all the gameobjects with the tag "coin" then load the next scene when they are no more
            coins = GameObject.FindGameObjectsWithTag("Coin");
            if (coins.Length == 0)
            {
                Unlocklevel[SceneManager.GetActiveScene().buildIndex - 1] = true;
                // Save the state of unlocked levels
                SaveUnlockedLevel();

                if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //if it went through all the levels available, redirects to Menu (build index 0)
                else
                    SceneManager.LoadScene(0);
            }
        }
    }

    public void LoadUnlockedLevel()
    {
        // Load UnlockedLevelState
        if (PlayerPrefs.HasKey("Level3"))
        {
            Unlocklevel[0] = (PlayerPrefs.GetInt("Level1") == 1 ? true : false);
            Unlocklevel[1] = (PlayerPrefs.GetInt("Level2") == 1 ? true : false);
            Unlocklevel[2] = (PlayerPrefs.GetInt("Level3") == 1 ? true : false);
            Unlocklevel[3] = (PlayerPrefs.GetInt("Level4") == 1 ? true : false);
            Unlocklevel[4] = (PlayerPrefs.GetInt("Level5") == 1 ? true : false);
        }
        else
        {
            Debug.Log("No Save");
        }
    }

    public void SaveUnlockedLevel()
    {
        // Save UnlockedLevelState
        PlayerPrefs.SetInt("Level1", (Unlocklevel[0] ? 1 : 0));
        PlayerPrefs.SetInt("Level2", (Unlocklevel[1] ? 1 : 0));
        PlayerPrefs.SetInt("Level3", (Unlocklevel[2] ? 1 : 0));
        PlayerPrefs.SetInt("Level4", (Unlocklevel[3] ? 1 : 0));
        PlayerPrefs.SetInt("Level5", (Unlocklevel[4] ? 1 : 0));

        PlayerPrefs.Save();
    }

    // Functions to load the levels based on the build index(Go to File->BuildSettings to manage it)

    public void GotoLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void GotoLevel2()
    {
        if (Unlocklevel[0] == true)
            SceneManager.LoadScene(2);
    }

    public void GotoLevel3()
    {
        if (Unlocklevel[1] == true)
            SceneManager.LoadScene(3);
    }

    public void GotoLevel4()
    {
        if (Unlocklevel[2] == true)
            SceneManager.LoadScene(4);
    }

    public void GotoLevel5()
    {
        if (Unlocklevel[3] == true)
            SceneManager.LoadScene(5);
    }

    public void GotoLevel6()
    {
        if (Unlocklevel[4] == true)
            SceneManager.LoadScene(6);
    }

    public void GotoLevel7()
    {
        if (Unlocklevel[5] == true)
            SceneManager.LoadScene(7);
    }

    public void GotoLevel8()
    {
        if (Unlocklevel[6] == true)
            SceneManager.LoadScene(8);
    }

    public void GotoLevel9()
    {
        if (Unlocklevel[7] == true)
            SceneManager.LoadScene(9);
    }

    public void GotoLevel10()
    {
        if (Unlocklevel[8] == true)
            SceneManager.LoadScene(10);
    }
}
