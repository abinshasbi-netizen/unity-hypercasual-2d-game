using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour,
    IUnityAdsInitializationListener,
    IUnityAdsLoadListener,
    IUnityAdsShowListener
{
    public static AdsManager Instance;

    
    private string gameId = "6045193"; 
    private string interstitialId = "Interstitial_Android";

    private string rewardedId = "Rewarded_Android";

    private bool testMode = true;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
       
    }

    void Start()
    {
        Advertisement.Initialize(gameId, testMode, this);
    }

   
    public void LoadInterstitial()
    {
        Advertisement.Load(interstitialId, this);
    }

    public void LoadRewarded()
    {
        Advertisement.Load(rewardedId, this);
    }


    public void ShowInterstitial()
    {
        Advertisement.Show(interstitialId, this);
    }

    public void ShowRewarded()
    {
        Advertisement.Show(rewardedId, this);
    }


    public void OnInitializationComplete()
    {
        LoadInterstitial();
        LoadRewarded();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError(message);
    }

    public void OnUnityAdsAdLoaded(string placementId) { }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError(message);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState state)
    {
        if (placementId == rewardedId && state == UnityAdsShowCompletionState.COMPLETED)
        {

           GamePlayManagement.Instance.ResumeGame();
        }

        LoadInterstitial();
        LoadRewarded();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }
    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }
}
