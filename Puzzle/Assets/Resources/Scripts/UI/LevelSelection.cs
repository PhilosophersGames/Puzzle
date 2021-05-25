using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Gameobject array to get reference of all the Coins in the scene

    private GameObject[] coins;

    [SerializeField]
    private int[] Unlocklevel;

    public AchievementManager achievementManager;

    public AchievementLeastRotations achievementLeastRotations;

    public GameObject UIEndScreen;

    public GameObject scoreStars;

    public bool[] rewardLevels;

    void Awake()
    {
        Unlocklevel = new int[SceneManager.sceneCountInBuildSettings - 1];
        rewardLevels = new bool[SceneManager.sceneCountInBuildSettings];
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
                if (Unlocklevel[SceneManager.GetActiveScene().buildIndex] == 0)
                    Unlocklevel[SceneManager.GetActiveScene().buildIndex] = 1;
                Unlocklevel[SceneManager.GetActiveScene().buildIndex - 1] = 2;
                SaveUnlockedLevel();
                EndScreen();
                RewardPlayer();
                AchievementsGestion();
            }
        }
    }

    public void RewardPlayer()
    {
        if (PlayerPrefs.GetInt($"RewardLevel{SceneManager.GetActiveScene().buildIndex.ToString()}") == 0)
        {
            GameObject.FindGameObjectWithTag("User").GetComponent<User>().UpdateUserMoney(100);
            rewardLevels[SceneManager.GetActiveScene().buildIndex - 1] = true;
            PlayerPrefs.SetInt($"RewardLevel{SceneManager.GetActiveScene().buildIndex.ToString()}", 1);
            PlayerPrefs.Save();
        }
    }

    public void EndScreen()
    { 
       if (UIEndScreen)
            UIEndScreen.SetActive(true);
        GameObject.FindGameObjectWithTag("LevelManager").SendMessage("StopTimer");
        scoreStars.SendMessage("LevelScore", (SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void AchievementsGestion()
    {
        if (achievementLeastRotations.rotationNumbers < 36 && achievementLeastRotations.achievement == true)
            achievementManager.UnlockAchievement(Achievements.MasterMind);
        if (SceneManager.GetActiveScene().buildIndex == 7)
            achievementManager.UnlockAchievement(Achievements.Chapter1);
        if (SceneManager.GetActiveScene().buildIndex == 15)
            achievementManager.UnlockAchievement(Achievements.Chapter2);
        if (SceneManager.GetActiveScene().buildIndex == 23)
            achievementManager.UnlockAchievement(Achievements.Chapter3);
        if (SceneManager.GetActiveScene().buildIndex == 31)
            achievementManager.UnlockAchievement(Achievements.Chapter4);
        if (SceneManager.GetActiveScene().buildIndex == 39)
            achievementManager.UnlockAchievement(Achievements.Chapter5);
    }

    public string GetLevelName(int chapterNumber, int i)
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
            for (int level = 0; level <= 63; level++)
            {
                i++;
                Unlocklevel[level] = (PlayerPrefs.GetInt(GetLevelName(chapterNumber, i + 1)));
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
        for (int level = 0; level <= 63; level++)
        {
            i++;
            PlayerPrefs.SetInt(GetLevelName(chapterNumber, i + 1), (Unlocklevel[level]));
            if (level == 7 || level == 15 || level == 23 || level == 31 || level == 39 || level == 47 || level == 55)
            {
                i = -1;
                chapterNumber++;
            }
        }
        PlayerPrefs.Save();
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
        if (i == 1)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(i);
    }

  /* public void UnlockLevelsTest()
    {
        int chapterNumber = 1;
        int i = -1;

        for (int level = 0; level <= 43; level++)
        {
            i++;
            if (Unlocklevel[level] == 0)
                Unlocklevel[level] = 1;
            PlayerPrefs.SetInt(GetLevelName(chapterNumber, i + 1), (Unlocklevel[level] ? 1 : 0));
            Unlocklevel[level] = PlayerPrefs.GetInt(GetLevelName(chapterNumber, i + 1));
            if (level == 7 || level == 15 || level == 23 || level == 31 || level == 39 || level == 43 || level == 51 || level == 59)
            {
                i = -1;
                chapterNumber++;
            }
        }
        SceneManager.LoadScene(0);
    }
    */
}