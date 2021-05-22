using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


[ExecuteInEditMode]
public class Stage : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]

    private TextMeshProUGUI[] stageNumberText;

    [SerializeField]

    private GameObject[] buttonState;

    [Header("Stage Infos")]
    [SerializeField]
    private int number;

    private int stageState;

    private int chapterNumber;

    public void Awake()
    {
        stageNumberText[0].text = number.ToString();
        stageNumberText[1].text = number.ToString();
        chapterNumber = GetComponentInParent<GroupStage>().groupStageId;
    }

    public void Start()
    {
        StageInit();
    }

    public void GotoStageLevel()
    {
        GetComponentInParent<LevelSelection>().GoToLevel((8 * (chapterNumber - 1) + number));
        Debug.Log((8 * (chapterNumber - 1) + number));
    }

    public void StageInit()
    {

        // Check inside side the savesystem on which state the level is (0 - Lock, 1 - Default, 2 - Complete)
       if (PlayerPrefs.GetInt(GetComponentInParent<LevelSelection>().GetLevelName(chapterNumber, number)) == 0)
       {
            if(number != 1)
                stageState = 0;
       }
       if(PlayerPrefs.GetInt(GetComponentInParent<LevelSelection>().GetLevelName(chapterNumber, number)) == 1 || number == 1) 
        {
            stageState = 1;
        }
               if(PlayerPrefs.GetInt(GetComponentInParent<LevelSelection>().GetLevelName(chapterNumber, number)) == 2) 
        {
            stageState = 2;
        }

        // Set here The GameObject accordingly to the states
        if (stageState == 0)
        {
            buttonState[0].gameObject.SetActive(true);
            buttonState[1].gameObject.SetActive(false);
            buttonState[2].gameObject.SetActive(false);
        }
        else if (stageState == 1)
        {
            buttonState[0].gameObject.SetActive(false);
            buttonState[1].gameObject.SetActive(true);
            buttonState[2].gameObject.SetActive(false);
        }
        else if (stageState == 2)
        {
            buttonState[0].gameObject.SetActive(false);
            buttonState[1].gameObject.SetActive(false);
            buttonState[2].gameObject.SetActive(true);
            buttonState[2].GetComponent<StageStars>().StarManagement(PlayerPrefs.GetInt(GetComponentInParent<Score>().GetStarScoreName(chapterNumber, number)));
        }
    }
}
