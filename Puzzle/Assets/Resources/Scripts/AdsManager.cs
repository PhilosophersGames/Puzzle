using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
{
    private const string MaxSdkKey = "tLxZHAemiZ1tuwIQbt8N2G-imGZINgShlz7b33by00Fy6qP8rOJ0zzPdzpArEnBeI7e5c5ZXvTRU_bDieTiiZf";
    private const string RewardedAdUnitId = "9a93e73ff295f688";
    private const string RewardedAdUnitIdAndroid = "6f36fbc950e51236";

    public Button showRewardedButton; 
    private int rewardedRetryAttempt;
    public GameObject user;
    [SerializeField] private RewardAnimation rewardAnimation;
    [SerializeField] private bool isMenu;

    void Start()
    {
            showRewardedButton.onClick.AddListener(ShowRewardedAd);

        if (isMenu)
        {
        MaxSdkCallbacks.OnSdkInitializedEvent += sdkConfiguration =>
        {
                // AppLovin SDK is initialized, configure and start loading ads.
                Debug.Log("MAX SDK Initialized");

                InitializeRewardedAds();
                MaxSdk.ShowMediationDebugger();
            };

            MaxSdk.SetSdkKey(MaxSdkKey);
            MaxSdk.InitializeSdk();
            }
    }

    #region Rewarded Ad Methods

    private void InitializeRewardedAds()
    {
        // Attach callbacks
        MaxSdkCallbacks.OnRewardedAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.OnRewardedAdLoadFailedEvent += OnRewardedAdFailedEvent;
        MaxSdkCallbacks.OnRewardedAdFailedToDisplayEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.OnRewardedAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.OnRewardedAdClickedEvent += OnRewardedAdClickedEvent;
        MaxSdkCallbacks.OnRewardedAdHiddenEvent += OnRewardedAdDismissedEvent;
        MaxSdkCallbacks.OnRewardedAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        // Load the first RewardedAd
        LoadRewardedAd();
    }

    private void LoadRewardedAd()
    {
        #if UNITY_IOS
        MaxSdk.LoadRewardedAd(RewardedAdUnitId);
        #endif
        #if UNITY_ANDROID
        MaxSdk.LoadRewardedAd(RewardedAdUnitIdAndroid);
        #endif
    }

    public void ShowRewardedAd()
    {
        #if UNITY_IOS
        if (MaxSdk.IsRewardedAdReady(RewardedAdUnitId))
        {
            MaxSdk.ShowRewardedAd(RewardedAdUnitId);
        }
        else
        {
           Debug.Log("Rewarded not ready");
        }
        #endif
        #if UNITY_ANDROID
        if (MaxSdk.IsRewardedAdReady(RewardedAdUnitIdAndroid))
        {
            MaxSdk.ShowRewardedAd(RewardedAdUnitIdAndroid);
        }
        else
        {
           Debug.Log("Rewarded not ready");
        }
        #endif
    }

    private void OnRewardedAdLoadedEvent(string adUnitId)
    {
        // Rewarded ad is ready to be shown. MaxSdk.IsRewardedAdReady(rewardedAdUnitId) will now return 'true'
        Debug.Log("Rewarded ad loaded");
        
        // Reset retry attempt
        rewardedRetryAttempt = 0;
    }

    private void OnRewardedAdFailedEvent(string adUnitId, int errorCode)
    {
        // Rewarded ad failed to load. We recommend retrying with exponentially higher delays up to a maximum delay (in this case 64 seconds).
        rewardedRetryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, rewardedRetryAttempt));
        
        Debug.Log("Rewarded ad failed to load with error code: " + errorCode);
        
        Invoke("LoadRewardedAd", (float) retryDelay);
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, int errorCode)
    {
        // Rewarded ad failed to display. We recommend loading the next ad
        Debug.Log("Rewarded ad failed to display with error code: " + errorCode);
        LoadRewardedAd();
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId)
    {
        Debug.Log("Rewarded ad displayed");
    }

    private void OnRewardedAdClickedEvent(string adUnitId)
    {
        Debug.Log("Rewarded ad clicked");
    }

    private void OnRewardedAdDismissedEvent(string adUnitId)
    {
        // Rewarded ad is hidden. Pre-load the next ad
        Debug.Log("Rewarded ad dismissed");
        LoadRewardedAd();
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward)
    {
        // Rewarded ad was displayed and user should receive the reward
        user = GameObject.FindWithTag("User");
        user.GetComponent<User>().UpdateUserMoney(100);
        if(!isMenu)
        {
            rewardAnimation.UpdateRewardAmount(100);
          //  showRewardedButton.gameObject.SetActive(false);
        }
        Debug.Log("Rewarded ad received reward");
    }
    #endregion
}