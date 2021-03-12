using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementItemController : MonoBehaviour
{
    [SerializeField] Image unlockedIcon;
    [SerializeField] Image lockedIcon;

    [SerializeField] TextMeshProUGUI titleLabel;
    [SerializeField] TextMeshProUGUI descriptionLabel;

    public bool unlocked;
    
    #pragma warning disable 0649

    public Achievement achievement;

    public void RefreshView()
    {
        titleLabel.text = achievement.title;
        descriptionLabel.text = achievement.description;

        unlockedIcon.enabled = unlocked;
        lockedIcon.enabled = !unlocked;
    }

    private void OnValidate()
    {
        RefreshView();
    }
}


