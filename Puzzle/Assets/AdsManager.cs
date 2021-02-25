using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string gameId = "rewardedVideo";

    void Start()
    {
        Advertisement.AddListener(this);    
        Advertisement.Initialize("4016577", true);
    }

    public void ShowAd(string p)
    {
        Advertisement.Show(p);
    }

    public void OnUnityAdsDidFinish(string gameId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            GameObject.Find("User").transform.GetComponent<User>().wallet += 100;
         //   Advertisement.RemoveListener(this);
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("FAIL");
        }
    }
    public void OnUnityAdsDidStart(string gameId)
    {

    }
    public void OnUnityAdsReady(string gameId)
    {
    }

    public void OnUnityAdsDidError(string gameId)
    {
    } 
}
