using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardAnimation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private int gold;
    [SerializeField] private int amount;

    void Update()
    {
        if (gold < amount)
        {
            gold += 2;
            goldText.text = $"+{gold.ToString()}";
        }
    }
    
    public void UpdateRewardAmount(int newValue)
    {
        amount += newValue;
    }
}
