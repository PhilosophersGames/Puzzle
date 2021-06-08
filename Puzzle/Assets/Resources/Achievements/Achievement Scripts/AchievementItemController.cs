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
    [SerializeField] private GameObject stampImg;

    public bool unlocked;
    
    #pragma warning disable 0649

    public Achievement achievement;

    private bool rewardReceived;

    public void RefreshView()
    {
        titleLabel.text = achievement.title;
        descriptionLabel.text = achievement.description;

        unlockedIcon.enabled = unlocked;
        lockedIcon.enabled = !unlocked;

        if(PlayerPrefs.GetInt($"{achievement.id.ToString()}rewardReceived", 0) == 1)
        {
            rewardReceived = true;
            stampImg.SetActive(true);
        }
    }

    private void OnValidate()
    {
        RefreshView();
    }

    public void GetReward()
    {
        if (PlayerPrefs.GetInt(achievement.id, 0) == 1 && !rewardReceived)
        {
            stampImg.SetActive(true);
            // Need to work on a function which returns multiple reward outputs (coins, trails, skins, colors...)//
            GameObject.Find("User").transform.GetComponent<User>().UpdateUserMoney(achievement.reward);
            rewardReceived = true;
            PlayerPrefs.SetInt($"{achievement.id.ToString()}rewardReceived", 1);
        }
    }
}