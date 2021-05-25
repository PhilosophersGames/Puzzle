using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GroupStage : MonoBehaviour
{
    public int groupStageId;
    public int minimumStarScore;
    [SerializeField] private TextMeshProUGUI chapterText;
    [SerializeField] private TextMeshProUGUI minimumStarText;

    public void Start()
    {
        chapterText.text = groupStageId.ToString();
        minimumStarText.text = minimumStarScore.ToString();
    }
}