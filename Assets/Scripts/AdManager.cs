// using UnityEngine;
// using GoogleMobileAds.Api;

// public class AdManager : MonoBehaviour {

//     private static AdManager _instance;
//     public static AdManager Instance {
//         get {
//             if (_instance == null) {
//                 GameObject adManager = new GameObject("AdManager");
//                 adManager.AddComponent<AdManager>();
//             }
//             return _instance;
//         }
//     }
//     public BannerView bannerView;
//     public InterstitialAd interstitial;
//     public RewardBasedVideoAd rewardBasedVideo;

//     public int IsTimeToShowInterstitial { get; set; }
//     public int InstructionsShown { get; set; }

//     private SecondChanceMenu sc;

//     void Awake() {
//         _instance = this;
//         InstructionsShown = 0;
//     }

//     public void Start() {
//         DontDestroyOnLoad(gameObject);
//         sc = FindObjectOfType<SecondChanceMenu>();

//         #if UNITY_ANDROID
//             string appId = "ca-app-pub-1486428121637234~2287583426";
//         #elif UNITY_IPHONE
//             string appId = "ca-app-pub-3940256099942544~1458002511";
//         #else
//             string appId = "unexpected_platform";
//         #endif

//         // Initialize the Google Mobile Ads SDK.
//         MobileAds.Initialize(appId);

//         // Get singleton reward based video ad reference.
//         rewardBasedVideo = RewardBasedVideoAd.Instance;

//         //RequestBottomBanner();
//         //RequestInterstitial();
//         //RequestRewardBasedVideo();

//     }

//     public void RequestBottomBanner() {
// #if UNITY_ANDROID
//         //string adUnitId = "ca-app-pub-1486428121637234/9366205089";//realID
//         string adUnitId = "a-app-pub-3940256099942544/6300978111"; //testID
// #elif UNITY_IPHONE
//             string adUnitId = "ca-app-pub-3940256099942544/2934735716";
// #else
//             string adUnitId = "unexpected_platform";
// #endif

//         // Create a 320x50 banner at the top of the screen.
//         bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);//AdSize.Banner

//         // Create an empty ad request.
//         AdRequest request = new AdRequest.Builder().Build();

//         // Load the banner with the request.
//         bannerView.LoadAd(request);
//     }

//     public void RequestInterstitial() {
// #if UNITY_ANDROID
//         //string adUnitId = "ca-app-pub-1486428121637234/6819932796";//realID
//         string adUnitId = "ca-app-pub-3940256099942544/1033173712"; //tesID
// #elif UNITY_IPHONE
//             string adUnitId = "ca-app-pub-3940256099942544/4411468910";
// #else
//             string adUnitId = "unexpected_platform";
// #endif

//         // Initialize an InterstitialAd.
//         interstitial = new InterstitialAd(adUnitId);

//         // Create an empty ad request.
//         AdRequest request = new AdRequest.Builder().Build();
//         // Load the interstitial with the request.
//         interstitial.LoadAd(request);
//     }

//     public void RequestRewardBasedVideo() {
//         #if UNITY_ANDROID
//             //string adUnitId = "ca-app-pub-1486428121637234/9899491899"; //realID
//             string adUnitId = "ca-app-pub-3940256099942544/5224354917";//testID
//         #elif UNITY_IPHONE
//             string adUnitId = "ca-app-pub-3940256099942544/1712485313";
//         #else
//             string adUnitId = "unexpected_platform";
//         #endif

//         AdRequest request = new AdRequest.Builder().Build();
//         rewardBasedVideo.LoadAd(request, adUnitId);
//     }

//     public void ShowInterstitial() {
//         if (interstitial.IsLoaded()) {
//             interstitial.Show();
//         }
//     }

    
// }
