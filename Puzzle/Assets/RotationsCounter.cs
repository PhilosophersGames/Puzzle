using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotationsCounter : MonoBehaviour
{
    public TextMeshProUGUI rotationText;

    private int rotationsNumber;

    void Start()
    {
        rotationText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        rotationText.text = RoomTransition.HamsterRotation.ToString();
    }
}
