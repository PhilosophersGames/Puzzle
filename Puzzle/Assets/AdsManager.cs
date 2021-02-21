using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string placement = "rewardedVideo";

    private int philosophersCoins;

    void Start()
    {
        philosophersCoins = GameObject.Find("Philosophers Coins").transform.GetComponent<PhilosophersCoins>().philoshophersCoins;
        Advertisement.AddListener(this);
        Advertisement.Initialize("4016577", true);
    }

    public void ShowAd(string p)
    {
        Advertisement.Show(p);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            // Reward
            Debug.Log("WIN");
            philosophersCoins += 100;
            Advertisement.RemoveListener(this);
        }
        else if (showResult == ShowResult.Failed)
        {
            // Fail
            Debug.Log("FAIL");
        }

    }
    public void OnUnityAdsDidStart(string placementId)
    {

    }
    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string placementId)
    {
    } 
}
