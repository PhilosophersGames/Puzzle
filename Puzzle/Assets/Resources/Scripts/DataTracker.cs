using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI rotationText;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rotationText.text = RoomTransition.HamsterRotation.ToString();
    }
}
