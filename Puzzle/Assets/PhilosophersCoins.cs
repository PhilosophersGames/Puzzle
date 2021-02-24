using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PhilosophersCoins : MonoBehaviour
{
    public int philosophersCoins;
    void Start()
    {
       // philosophersCoins = GameObject.Find("Ads Manager").transform.GetComponent<AdsManager>().philosophersCoins;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = GameObject.Find("Ads Manager").transform.GetComponent<AdsManager>().philosophersCoins.ToString();
    }
}
