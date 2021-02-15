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
    public AchievementLeastRotations achievementLeastRotations;
    private GameObject UIEndScreen;

    void Awake()
    {
        //        achievementLeastRotations =  GameObject.Find("AchievementLeastRotations").GetComponent<AchievementLeastRotations>();
        //ScreenCapture.CaptureScreenshot("C:/Users/youce/Desktop/JEU DE CARTE/PNG/Temp");
        Unlocklevel = new bool[SceneManager.sceneCountInBuildSettings - 1];
        LoadUnlockedLevel();
    }

    private void Start()
    {
        UIEndScreen = GameObject.Find("/GameManager/UIcanvas/End Screen");
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
                UnlockNewChapter();
                SaveUnlockedLevel();
                AchievementsGestion();
                EndScreen();
                //if it went through all the levels available, redirects to Menu (build index 0)
            }
        }
    }

    public void EndScreen()
    {
        GameObject.Find("/GameManager/LevelManager").SendMessage("StopTimer");
        UIEndScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void AchievementsGestion()
    {
        if (achievementLeastRotations.rotationNumbers < 36 && achievementLeastRotations.achievement == true)
            achievementManager.UnlockAchievement(Achievements.MasterMind);
        if (Unlocklevel[6] == true)
            achievementManager.UnlockAchievement(Achievements.Chapter1);
        if (Unlocklevel[10] == true)
            achievementManager.UnlockAchievement(Achievements.Chapter2);
        if (Unlocklevel[16] == true)
            achievementManager.UnlockAchievement(Achievements.Chapter3);
        if (Unlocklevel[21] == true)
            achievementManager.UnlockAchievement(Achievements.Chapter4);
        if (Unlocklevel[27] == true)
            achievementManager.UnlockAchievement(Achievements.Chapter5);
    }

    private string GetLevelName(int chapterNumber, int i)
    {
        string tab = $"C{chapterNumber.ToString()}Level{i.ToString()}";
        return (tab);
    }
    public void LoadUnlockedLevel()
    {
        // Load UnlockedLevelState
        if (PlayerPrefs.HasKey("C2Level3"))
        {
            int chapterNumber = 1;
            int i = -1;
            for(int level = 0; level <= 27; level++)
            {
                i++;
                Unlocklevel[level] = (PlayerPrefs.GetInt(GetLevelName(chapterNumber, i+1)) == 1 ? true : false);
                if(level == 6 || level == 10 || level == 16 || level == 20 || level == 27)
                {
                    i = -1;
                    chapterNumber++;
                }
            }
        }
        else
            Debug.Log("No Save");
    }

    public void SaveUnlockedLevel()
    {
        // Save UnlockedLevelState
        int chapterNumber = 1;
        int i = -1;
        for(int level = 0; level <= 27; level++)
        {
            i++;
            PlayerPrefs.SetInt(GetLevelName(chapterNumber, i+1), (Unlocklevel[level] ? 1 : 0));
            if(level == 6 || level == 10 || level == 16 || level == 20 || level == 27)
            {
                i = -1;
                chapterNumber++;
            }
        }
        PlayerPrefs.Save();
    }

    void UnlockNewChapter()
    {
        if (Unlocklevel[5]) 
        {
            Unlocklevel[6] = true;
        }
        if (Unlocklevel[9]) 
        {
            Unlocklevel[10] = true;
        }
        if (Unlocklevel[15]) 
        {
            Unlocklevel[16] = true;
        }
        if (Unlocklevel[19]) 
        {
            Unlocklevel[20] = true;
        }
    }

    // Functions to load the levels based on the build index(Go to File->BuildSettings to manage it)


    public void GoToNexLevel()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
            achievementManager.UnlockAchievement(Achievements.End);
        }
    }

    //Chapter 1
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

    // Chapter 5
    public void GotoChapter5Level1()
    {
        if (Unlocklevel[20] == true)
            SceneManager.LoadScene(22);
    }

    public void GotoChapter5Level2()
    {
        if (Unlocklevel[21] == true)
            SceneManager.LoadScene(23);
    }
    public void GotoChapter5Level3()
    {
        if (Unlocklevel[22] == true)
            SceneManager.LoadScene(24);
    }
    public void GotoChapter5Level4()
    {
        if (Unlocklevel[23] == true)
            SceneManager.LoadScene(25);
    }
    public void GotoChapter5Level5()
    {
        if (Unlocklevel[24] == true)
            SceneManager.LoadScene(26);
    }
    public void GotoChapter5Level6()
    {
        if (Unlocklevel[25] == true)
            SceneManager.LoadScene(27);
    }

    // Chapter Final
    public void GotoChapterFLevel1()
    {
        if (Unlocklevel[26] == true)
            SceneManager.LoadScene(28);
    }
}