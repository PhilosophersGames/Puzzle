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
    public GameObject UIEndScreen;

    public bool[] rewardLevels;

    void Awake()
    {
        Unlocklevel = new bool[SceneManager.sceneCountInBuildSettings - 1];
        rewardLevels = new bool[SceneManager.sceneCountInBuildSettings];
        LoadUnlockedLevel();
    }

    private void Start()
    {
        UnlockNewChapter();
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
                RewardPlayer();
                SaveUnlockedLevel();
                EndScreen();
            //    AchievementsGestion();
            }
        }
    }

    public void RewardPlayer()
    {
        if (!rewardLevels[SceneManager.GetActiveScene().buildIndex - 1])
            GameObject.FindGameObjectWithTag("User").GetComponent<User>().UpdateUserMoney(100);
        rewardLevels[SceneManager.GetActiveScene().buildIndex - 1] = true;
    }
    public void EndScreen()
    {
        GameObject.FindGameObjectWithTag("LevelManager").SendMessage("StopTimer");
        if (UIEndScreen)
            UIEndScreen.SetActive(true);
    }

    public void AchievementsGestion()
    {
        if (achievementLeastRotations.rotationNumbers < 36 && achievementLeastRotations.achievement == true)
            achievementManager.UnlockAchievement(Achievements.MasterMind);
        if (SceneManager.GetActiveScene().buildIndex == 7)
            achievementManager.UnlockAchievement(Achievements.Chapter1);
        if (SceneManager.GetActiveScene().buildIndex == 11)
            achievementManager.UnlockAchievement(Achievements.Chapter2);
        if (SceneManager.GetActiveScene().buildIndex == 17)
            achievementManager.UnlockAchievement(Achievements.Chapter3);
        if (SceneManager.GetActiveScene().buildIndex == 21)
            achievementManager.UnlockAchievement(Achievements.Chapter4);
        if (SceneManager.GetActiveScene().buildIndex == 28)
            achievementManager.UnlockAchievement(Achievements.Chapter5);
    }

    private string GetLevelName(int chapterNumber, int i)
    {
        string tab = $"C{chapterNumber.ToString()}Level{i.ToString()}";
        return (tab);
    }
    public void LoadUnlockedLevel()
    {
        if (PlayerPrefs.HasKey("C2Level3"))
        {
            int chapterNumber = 1;
            int i = -1;
            for (int level = 0; level <= 43; level++)
            {
                i++;
                Unlocklevel[level] = (PlayerPrefs.GetInt(GetLevelName(chapterNumber, i + 1)) == 1 ? true : false);
                if (level == 7 || level == 15 || level == 23 || level == 31 || level == 39 || level == 47 || level == 55)
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
        int chapterNumber = 1;
        int i = -1;
        for (int level = 0; level <= 62; level++)
        {
            i++;
            PlayerPrefs.SetInt(GetLevelName(chapterNumber, i + 1), (Unlocklevel[level] ? 1 : 0));
            if (level == 7 || level == 15 || level == 23 || level == 31 || level == 39 || level == 47 || level == 55)
            {
                i = -1;
                chapterNumber++;
            }
        }
        PlayerPrefs.Save();
    }
    public void UnlockNewChapter()
    {
        Unlocklevel[7] = true;
        Unlocklevel[15] = true;
        Unlocklevel[23] = true;
        Unlocklevel[31] = true;
        Unlocklevel[39] = true;
        Unlocklevel[47] = true;
        Unlocklevel[55] = true;
        SaveUnlockedLevel();
    }
    public void GoToNexLevel()
    {

        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 == 9 || SceneManager.GetActiveScene().buildIndex + 1 == 17 || SceneManager.GetActiveScene().buildIndex + 1 == 25 || SceneManager.GetActiveScene().buildIndex + 1 == 33 || SceneManager.GetActiveScene().buildIndex + 1 == 41 || SceneManager.GetActiveScene().buildIndex + 1 == 49 || SceneManager.GetActiveScene().buildIndex + 1 == 57)
            {
                SceneManager.LoadScene(0);
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void GoToLevel(int i)
    {
        if (i == -1)
            SceneManager.LoadScene(1);
        else if (Unlocklevel[i] == true)
            SceneManager.LoadScene(i + 2);
    }
    public void UnlockLevelsTest()
    {
        int chapterNumber = 1;
        int i = -1;

        for (int level = 0; level <= 43; level++)
        {
            i++;
            if (Unlocklevel[level] == false)
                Unlocklevel[level] = true;
            PlayerPrefs.SetInt(GetLevelName(chapterNumber, i + 1), (Unlocklevel[level] ? 1 : 0));
            Unlocklevel[level] = (PlayerPrefs.GetInt(GetLevelName(chapterNumber, i + 1)) == 1 ? true : false);
            if (level == 7 || level == 15 || level == 23 || level == 31 || level == 39 || level == 43 || level == 51 || level == 59)
            {
                i = -1;
                chapterNumber++;
            }
        }
        SceneManager.LoadScene(0);
    }
}