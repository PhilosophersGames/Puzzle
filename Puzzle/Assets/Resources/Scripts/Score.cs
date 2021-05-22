using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField]
    private int chapterId;

    [SerializeField]
    private int levelId;

    private int[] bestScores = { 2, 2, 5, 4, 4, 10, 9, 14,
                      2, 4, 4, 13, 7, 11, 12, 33,
                      2, 3, 11, 4, 12, 7, 25, 22,
                      1, 4, 6, 2, 5, 9, 7, 35,
                      3, 1, 2, 1, 1, 16, 9, 33,
                      2, 5, 4, 8, 9, 8, 0, 52,
                      1, 2, 3, 6, 4, 6, 16, 54,
                      3, 6, 6, 14, 15, 20, 22, 0 };

    public GameObject[] star;

    private int registeredStarScore;

    int TwoStarsLimit(int bestScore)
    {
        if (bestScore <= 2)
            return (bestScore + 1);
        else if (bestScore <= 4)
            return (bestScore + 2);
        else if (bestScore <= 8)
            return (bestScore + 3);
        else if (bestScore <= 16)
            return (bestScore + 4);
        else if (bestScore <= 32)
            return (bestScore + 5);
        else
            return (bestScore + 6);
    }

    void LevelScore(int level)
    {
        transform.GetComponent<TextMeshProUGUI>().text = bestScores[level].ToString();
        GetChapterAndLevelId();
        if (RoomTransition.HamsterRotation <= bestScores[level])
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);
            registeredStarScore = 3;
            SaveStarScore();
        }
        else if (RoomTransition.HamsterRotation <= TwoStarsLimit(bestScores[level]))
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            registeredStarScore = 2;
            SaveStarScore();
        }
        else
        {
            star[0].SetActive(true);
            registeredStarScore = 1;
            SaveStarScore();
        }
    }
            ///////////Score Save System//////////////

        ///Set PlayerPref String ID
        public string GetStarScoreName(int chapterNumber, int i)
    {
        string tab = $"StarScoreC{chapterNumber.ToString()}Level{i.ToString()}";
        return (tab);
    }

    /// Save StarScore of all the levels


    void GetChapterAndLevelId()
    {
        string tab = SceneManager.GetActiveScene().name;
        chapterId = tab[7] - '0';
        levelId = tab[14] - '0';
    }
    public void SaveStarScore()
    {
            if (PlayerPrefs.GetInt(GetStarScoreName(chapterId, levelId)) < registeredStarScore)
                PlayerPrefs.SetInt(GetStarScoreName(chapterId, levelId), registeredStarScore);  
        PlayerPrefs.Save();
    }
}
