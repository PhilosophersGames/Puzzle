using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardAnimation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private int gold;
                     private int frame;
    [SerializeField] private int speed;
    [SerializeField] private int amount;

    private void Start()
    {
        amount = 100;
    }

    void Update()
    {
        frame++;
        if (((amount / speed) %  frame) == 0 && gold < amount)
        {
            gold++;
            goldText.text = gold.ToString();
        }
    }
}
