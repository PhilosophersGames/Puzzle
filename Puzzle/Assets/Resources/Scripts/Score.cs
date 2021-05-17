using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score : MonoBehaviour
{
    private int[] bestScores = { 2, 2, 5, 4, 4, 10, 9, 14,
                      2, 4, 4, 13, 7, 11, 12, 33,
                      2, 3, 11, 4, 12, 7, 25, 22,
                      1, 4, 6, 2, 5, 9, 7, 35,
                      3, 1, 2, 1, 1, 16, 9, 33,
                      2, 5, 4, 8, 9, 8, 0, 52,
                      1, 2, 3, 6, 4, 6, 16, 54,
                      3, 6, 6, 14, 15, 20, 22, 0 };

    public GameObject[] star;

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
        if (RoomTransition.HamsterRotation <= bestScores[level])
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);
        }
        else if (RoomTransition.HamsterRotation <= TwoStarsLimit(bestScores[level]))
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
        }
        else
            star[0].SetActive(true);
    }
}
