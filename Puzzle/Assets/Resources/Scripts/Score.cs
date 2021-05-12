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
                      1, 2, 3, 6, 4, 6, 16, 0,
                      3, 6, 8, 14, 15, 20, 0, 0 };

    public Sprite[] scoreImages;

    public Image myImage;

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
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = bestScores[level].ToString();
        if (RoomTransition.HamsterRotation <= bestScores[level])
            myImage.sprite = scoreImages[0];
        else if (RoomTransition.HamsterRotation <= TwoStarsLimit(bestScores[level]))
            myImage.sprite = scoreImages[1];
        else
            myImage.sprite = scoreImages[2];
    }
}
