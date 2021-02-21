using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PhilosophersCoins : MonoBehaviour
{
    public int philoshophersCoins;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = philoshophersCoins.ToString();
    }
}
