using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityMonetization : MonoBehaviour, IUnityAdsListener
{
    string gameId = "4016577";
    string myPlacementId = "rewardedVideo";
    bool testMode = true;
    
    void Start()
    {
        Advertisement.AddListener (this);
        Advertisement.Initialize(gameId, testMode);
    }
    public void ShowInterstitialAd() 
    {
        if (Advertisement.IsReady())
            Advertisement.Show();
    } 
    
    public void DisplayVideoAD()
    {
        Advertisement.Show(myPlacementId);
    }
    public void OnUnityAdsDidFinish (string PlacementId, ShowResult showResult) 
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) 
        {
            // Reward the user for watching the ad to completion.
        } 
        else if (showResult == ShowResult.Skipped) 
        {
            // Do not reward the user for skipping the ad.
        } 
        else if (showResult == ShowResult.Failed) 
        {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady (string PlacementId) 
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (PlacementId == myPlacementId) 
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError (string message) 
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string PlacementId) 
    {
        // Optional actions to take when the end-users triggers an ad.
    } 

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() 
    {
        Advertisement.RemoveListener(this);
    }

    
}
