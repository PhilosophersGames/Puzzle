using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSelection : MonoBehaviour
{
    public AchievementManager achievementManager;
    private int[] chapterPrice;
    private bool[] unlockChapter;

    private GameObject[] chapters;
    private int wallet;
    
    void Start() 
    {
        chapters = GameObject.FindGameObjectsWithTag("Chapters");
        GetComponentInParent<LevelUnlockButtonProperties>().DisableChapters();
        // since index starts at 1 Length has to be + 1
        unlockChapter = new bool[chapters.Length + 1];
        chapterPrice = new int[chapters.Length + 1];
        LoadUnlockChapters();
        chapterPrice[1] = 0;
        chapterPrice[2] = 0;
        chapterPrice[3] = 0;
        chapterPrice[4] = 0;
        chapterPrice[5] = 0;
        chapterPrice[6] = 0;
        chapterPrice[7] = 0;
        chapterPrice[8] = 0;
    }

    public void BuyChapter(int i)
    {
        wallet = GameObject.Find("User").transform.GetComponent<User>().wallet;
        Debug.Log(chapterPrice[i]);
        {
            if (wallet >= chapterPrice[i])
            {
                GameObject.Find("User").transform.GetComponent<User>().UpdateUserMoney(-chapterPrice[i]);
                UnlockChapter(i);
            }
        }
    }
        private string GetChapterName(int chapterNumber)
    {
        string tab = $"Chapter{chapterNumber.ToString()}";
        return (tab);
    }

    public void UnlockChapter(int i)
    {
        unlockChapter[i] = true;        
        PlayerPrefs.SetInt(GetChapterName(i), 1);
        GetComponentInParent<LevelSelection>().UnlockNewChapter();
        GetComponentInParent<LevelUnlockButtonProperties>().UnlockImage();
        LoadUnlockChapters();

        if (unlockChapter[2] == true)
            achievementManager.UnlockAchievement(Achievements.UnlockChapter2);
        if (unlockChapter[3] == true)
            achievementManager.UnlockAchievement(Achievements.UnlockChapter3);
        if (unlockChapter[4] == true)
            achievementManager.UnlockAchievement(Achievements.UnlockChapter4);
        if (unlockChapter[5] == true)
            achievementManager.UnlockAchievement(Achievements.UnlockChapter5);
    }

    public void LoadUnlockChapters()
    {
        int i = 1;
        while(i <= chapters.Length)
        {
            unlockChapter[i] = PlayerPrefs.GetInt(GetChapterName(i)) == 1 ? true : false;
            if (unlockChapter[i])
            {
                transform.GetChild(i - 1).Find("BuyChapterButton").gameObject.SetActive(false);
                transform.GetChild(i - 1).Find("Buy confirmation").gameObject.SetActive(false);
                transform.GetChild(i - 1).GetComponent<Button>().interactable = true;
                transform.GetChild(i - 1).GetComponent<Image>().sprite = null;
            }
            i++;
        }
    }
}