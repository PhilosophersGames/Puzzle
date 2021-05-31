using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementsUnlock : MonoBehaviour
{
    private int counter = 0;

    public string GetLevelName(int chapterNumber, int i)
    {
        string tab = $"C{chapterNumber.ToString()}Level{i.ToString()}";
        return (tab);
    }

    public void UnlockChapterReward()
    {
        for (int chapterNumber = 1; chapterNumber < 9; chapterNumber++)
        {
            counter = 0;
            for (int i = 1; i < 9; i++)
            {
                if (PlayerPrefs.GetInt(GetLevelName(chapterNumber, i)) == 2)
                    counter++;
            }
            if (chapterNumber == 1 && counter >= 8)
                GetComponent<AchievementManager>().UnlockAchievement(Achievements.Chapter1);
            else if (chapterNumber == 2 && counter >= 8)
                GetComponent<AchievementManager>().UnlockAchievement(Achievements.Chapter2);
            else if (chapterNumber == 3 && counter >= 8)
                GetComponent<AchievementManager>().UnlockAchievement(Achievements.Chapter3);
            else if (chapterNumber == 4 && counter >= 8)
                GetComponent<AchievementManager>().UnlockAchievement(Achievements.Chapter4);
            else if (chapterNumber == 5 && counter >= 8)
                GetComponent<AchievementManager>().UnlockAchievement(Achievements.Chapter5);
            else if (chapterNumber == 6 && counter >= 8)
                GetComponent<AchievementManager>().UnlockAchievement(Achievements.Chapter6);
            else if (chapterNumber == 7 && counter >= 8)
                GetComponent<AchievementManager>().UnlockAchievement(Achievements.Chapter7);
            else if (chapterNumber == 8 && counter >= 8)
                GetComponent<AchievementManager>().UnlockAchievement(Achievements.Chapter8);
        }
    }
}
