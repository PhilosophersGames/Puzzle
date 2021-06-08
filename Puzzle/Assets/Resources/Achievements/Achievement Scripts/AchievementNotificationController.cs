using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
public class AchievementNotificationController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI achievementTitleLabel;
   // [SerializeField] TextMeshProUGUI achievementReward;

    private Animator Notification;

    private void Awake()
    {
        Notification = GetComponent<Animator>();
    }
    #pragma warning disable 0649
    public void ShowNotification(Achievement achievement)
    {
        achievementTitleLabel.text = achievement.title;
      //  achievementReward.text = achievement.reward.ToString();
        Notification.SetTrigger("Appear");
    }
}
