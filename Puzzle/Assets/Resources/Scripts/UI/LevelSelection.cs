using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Gameobject array to get reference of all the Coins in the scene
    private GameObject[] coins;
    public bool[] Unlocklevel;
    public AchievementManager achievementManager;


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
                AchievementsGestion();
                if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                //if it went through all the levels available, redirects to Menu (build index 0)
                else
                {
                    SceneManager.LoadScene(0);
                    achievementManager.UnlockAchievement(Achievements.End);
                }
            }
        }
    }

    public void AchievementsGestion()
    {
        if (Unlocklevel[6] == true)
            achievementManager.UnlockAchievement(Achievements.Chapter1);
        if (Unlocklevel[10] == true)
            achievementManager.UnlockAchievement(Achievements.Chapter2);
        if (Unlocklevel[16] == true)
            achievementManager.UnlockAchievement(Achievements.Chapter3);
        if (Unlocklevel[21] == true)
            achievementManager.UnlockAchievement(Achievements.Chapter4);
    }
    public void LoadUnlockedLevel()
    {
        // Load UnlockedLevelState
        if (PlayerPrefs.HasKey("C2Level3"))
        {
            Unlocklevel[0] = (PlayerPrefs.GetInt("C1Level1") == 1 ? true : false);
            Unlocklevel[1] = (PlayerPrefs.GetInt("C1Level2") == 1 ? true : false);
            Unlocklevel[2] = (PlayerPrefs.GetInt("C1Level3") == 1 ? true : false);
            Unlocklevel[3] = (PlayerPrefs.GetInt("C1Level4") == 1 ? true : false);
            Unlocklevel[4] = (PlayerPrefs.GetInt("C1Level5") == 1 ? true : false);
            Unlocklevel[5] = (PlayerPrefs.GetInt("C1Level6") == 1 ? true : false);
            Unlocklevel[6] = (PlayerPrefs.GetInt("C1Level7") == 1 ? true : false);

            Unlocklevel[7] = (PlayerPrefs.GetInt("C2Level1") == 1 ? true : false);
            Unlocklevel[8] = (PlayerPrefs.GetInt("C2Level2") == 1 ? true : false);
            Unlocklevel[9] = (PlayerPrefs.GetInt("C2Level3") == 1 ? true : false);
            Unlocklevel[10] = (PlayerPrefs.GetInt("C2Level4") == 1 ? true : false);

            Unlocklevel[11] = (PlayerPrefs.GetInt("C3Level1") == 1 ? true : false);
            Unlocklevel[12] = (PlayerPrefs.GetInt("C3Level2") == 1 ? true : false);
            Unlocklevel[13] = (PlayerPrefs.GetInt("C3Level3") == 1 ? true : false);
            Unlocklevel[14] = (PlayerPrefs.GetInt("C3Level4") == 1 ? true : false);
            Unlocklevel[15] = (PlayerPrefs.GetInt("C3Level5") == 1 ? true : false);
            Unlocklevel[16] = (PlayerPrefs.GetInt("C3Level6") == 1 ? true : false);

            Unlocklevel[17] = (PlayerPrefs.GetInt("C4Level1") == 1 ? true : false);
            Unlocklevel[18] = (PlayerPrefs.GetInt("C4Level2") == 1 ? true : false);
            Unlocklevel[19] = (PlayerPrefs.GetInt("C4Level3") == 1 ? true : false);
            Unlocklevel[20] = (PlayerPrefs.GetInt("C4Level4") == 1 ? true : false);
            Unlocklevel[21] = (PlayerPrefs.GetInt("C4Level5") == 1 ? true : false);
        }
        else
        {
            Debug.Log("No Save");
        }
    }

    public void SaveUnlockedLevel()
    {
        // Save UnlockedLevelState
        // chapter 1
        PlayerPrefs.SetInt("C1Level1", (Unlocklevel[0] ? 1 : 0));
        PlayerPrefs.SetInt("C1Level2", (Unlocklevel[1] ? 1 : 0));
        PlayerPrefs.SetInt("C1Level3", (Unlocklevel[2] ? 1 : 0));
        PlayerPrefs.SetInt("C1Level4", (Unlocklevel[3] ? 1 : 0));
        PlayerPrefs.SetInt("C1Level5", (Unlocklevel[4] ? 1 : 0));
        PlayerPrefs.SetInt("C1Level6", (Unlocklevel[5] ? 1 : 0));
        PlayerPrefs.SetInt("C1Level7", (Unlocklevel[6] ? 1 : 0));

        // chapter 2
        PlayerPrefs.SetInt("C2Level1", (Unlocklevel[7] ? 1 : 0));
        PlayerPrefs.SetInt("C2Level2", (Unlocklevel[8] ? 1 : 0));
        PlayerPrefs.SetInt("C2Level3", (Unlocklevel[9] ? 1 : 0));
        PlayerPrefs.SetInt("C2Level4", (Unlocklevel[10] ? 1 : 0));

        // chapter 3
        PlayerPrefs.SetInt("C3Level1", (Unlocklevel[11] ? 1 : 0));
        PlayerPrefs.SetInt("C3Level2", (Unlocklevel[12] ? 1 : 0));
        PlayerPrefs.SetInt("C3Level3", (Unlocklevel[13] ? 1 : 0));
        PlayerPrefs.SetInt("C3Level4", (Unlocklevel[14] ? 1 : 0));
        PlayerPrefs.SetInt("C3Level5", (Unlocklevel[15] ? 1 : 0));
        PlayerPrefs.SetInt("C3Level6", (Unlocklevel[16] ? 1 : 0));

        // chapter 4

        PlayerPrefs.SetInt("C4Level1", (Unlocklevel[17] ? 1 : 0));
        PlayerPrefs.SetInt("C4Level2", (Unlocklevel[18] ? 1 : 0));
        PlayerPrefs.SetInt("C4Level3", (Unlocklevel[19] ? 1 : 0));
        PlayerPrefs.SetInt("C4Level4", (Unlocklevel[20] ? 1 : 0));
        PlayerPrefs.SetInt("C4Level5", (Unlocklevel[21] ? 1 : 0));
        PlayerPrefs.Save();
    }

    // Functions to load the levels based on the build index(Go to File->BuildSettings to manage it)

//Chapter 0
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

//Chapter2
        public void GotoChapter2Level1()
    {
        if (Unlocklevel[6] == true)
            SceneManager.LoadScene(8);
    }
            public void GotoChapter2Level2()
    {
        if (Unlocklevel[7] == true)
            SceneManager.LoadScene(9);
    }
            public void GotoChapter2Level3()
    {
        if (Unlocklevel[8] == true)
            SceneManager.LoadScene(10);
    }
            public void GotoChapter2Level4()
    {
        if (Unlocklevel[9] == true)
            SceneManager.LoadScene(11);
    }

//Chapter 3
        public void GotoChapter3Level1()
    {
        if (Unlocklevel[10] == true)
            SceneManager.LoadScene(12);
    }
            public void GotoChapter3Level2()
    {
        if (Unlocklevel[11] == true)
            SceneManager.LoadScene(13);
    }
            public void GotoChapter3Level3()
    {
        if (Unlocklevel[12] == true)
            SceneManager.LoadScene(14);
    }
            public void GotoChapter3Level4()
    {
        if (Unlocklevel[13] == true)
            SceneManager.LoadScene(15);
    }
                public void GotoChapter3Level5()
    {
        if (Unlocklevel[14] == true)
            SceneManager.LoadScene(16);
    }
                public void GotoChapter3Level6()
    {
        if (Unlocklevel[15] == true)
            SceneManager.LoadScene(17);
    }

//Chapter 4
        public void GotoChapter4Level1()
    {
        if (Unlocklevel[16] == true)
            SceneManager.LoadScene(18);
    }
            public void GotoChapter4Level2()
    {
        if (Unlocklevel[17] == true)
            SceneManager.LoadScene(19);
    }
            public void GotoChapter4Level3()
    {
        if (Unlocklevel[18] == true)
            SceneManager.LoadScene(20);
    }
            public void GotoChapter4Level4()
    {
        if (Unlocklevel[19] == true)
            SceneManager.LoadScene(21);
    }
                public void GotoChapter4Level5()
    {
        if (Unlocklevel[20] == true)
            SceneManager.LoadScene(22);
    }
}