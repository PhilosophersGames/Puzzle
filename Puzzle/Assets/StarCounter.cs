using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarCounter : MonoBehaviour
{
    // Start is called before the first frame update

    private int starsTotal;
    // Update is called once per frame

    public void Start()
    {
        StarScoreCalculation();
    }

    private string GetStarScoreName(int chapterNumber, int i)
    {
        string tab = $"StarScoreC{chapterNumber.ToString()}Level{i.ToString()}";
        return (tab);
    }

    public void StarScoreCalculation()
    {
        int chapterNumber = 1;
        int i = -1;
        for (int level = 1; level <= 63; level++)
        {
            i++;
            starsTotal += PlayerPrefs.GetInt(GetStarScoreName(chapterNumber, i + 1));
            if (level == 8 || level == 16 || level == 24 || level == 32 || level == 40 || level == 48 || level == 56)
            {
                i = -1;
                chapterNumber++;
            }
        }
        GetComponent<TextMeshProUGUI>().text = starsTotal.ToString();
        PlayerPrefs.Save();
    }
}
